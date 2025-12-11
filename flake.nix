{
  description = "Nix flake for textEncryption with .NET 10 preferred and 9 fallback";

  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs { inherit system; };

        dotnetSdk10 = pkgs.dotnetCorePackages.sdk_10_0 or null;
        dotnetRuntime10 = pkgs.dotnetCorePackages.runtime_10_0 or null;
        dotnetSdk9 = pkgs.dotnetCorePackages.sdk_9_0;
        dotnetRuntime9 = pkgs.dotnetCorePackages.runtime_9_0;

        dotnetSdk =
          if dotnetSdk10 != null then dotnetSdk10 else dotnetSdk9;
        dotnetRuntime =
          if dotnetRuntime10 != null then dotnetRuntime10 else dotnetRuntime9;
        dotnetMajor =
          if dotnetSdk10 != null then "10" else "9";

        runScript = pkgs.writeShellApplication {
          name = "textEncryption-run";
          runtimeInputs = [ dotnetSdk ];
          text = ''
            set -euo pipefail
            project="${PWD}/textEncryption.csproj"
            if [ ! -f "$project" ]; then
              project="${self}/textEncryption.csproj"
            fi
            exec dotnet run --project "$project" "$@"
          '';
        };
      in {
        devShells.default = pkgs.mkShell {
          packages = [ dotnetSdk ];
          env = { DOTNET_ROOT = "${dotnetSdk}"; };
          shellHook = ''
            echo "Using .NET SDK ${dotnetMajor} from ${dotnetSdk}"
          '';
        };

        apps.default = flake-utils.lib.mkApp {
          drv = runScript;
        };
      });
}

