# textEncryption

Learning project to build a simple CLI text encryption tool. The aim is to practice designing a basic encryption algorithm, wire it into a .NET console app, and print the encrypted text back to the user.

## Goals

- Accept text input from the command line.
- Apply a straightforward, custom encryption/obfuscation algorithm.
- Return the encrypted result to the user.
- Serve as a playground to learn and iterate on encryption ideas in .NET.

### Running

Clone and enter the repo:

```sh
git clone https://github.com/your-username/textEncryption.git
cd textEncryption
```

With Nix (preferred; picks .NET 10 or falls back to 9):

```sh
nix develop   # enter shell with the SDK
dotnet run    # or nix run .#
```

With your locally installed .NET SDK:

```sh
dotnet run
```

### Next Steps

- Implement the encryption algorithm in `Program.cs`.
- Add tests/examples showing input → encrypted output.
- Document the algorithm and its limitations once chosen.
