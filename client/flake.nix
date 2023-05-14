{
  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs/nixpkgs-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    let
      forEachSystem = system: rec {
        # dev shell
        dev = {
          packages = with pkgs; [ nodejs nodePackages.pnpm ];
          scripts = { };
          envVarDefaults = { };
        };
        # dependencies
        buildInputs = [ ];
        nativeBuildInputs = [ ];
        # boilerplate
        pkgs = import nixpkgs { inherit system overlays; };
        overlays = [ ];
        packages = { };
        devShells.default = pkgs.mkShellNoCC {
          inherit buildInputs nativeBuildInputs;
          packages = dev.packages
            ++ builtins.attrValues (toBinScripts dev.scripts);
          shellHook = ''
            ${setEnvVarsIfUnset dev.envVarDefaults}
          '';
        };
        toBinScripts = scripts:
          (builtins.mapAttrs (name: text: (pkgs.writeShellScriptBin name text))
            scripts);
        setEnvVarsIfUnset = set:
          builtins.concatStringsSep "\n" (builtins.attrValues (builtins.mapAttrs
            (name: value: ''export ${name}=''${${name}:="${value}"}'') set));
      };
    in flake-utils.lib.eachDefaultSystem forEachSystem;
}
