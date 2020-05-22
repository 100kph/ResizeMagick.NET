# Sample Image Resizing using Magick.NET

### Prerequisites

- [x] I have written a descriptive issue title
- [ ] I have verified that I am using the latest version of Magick.NET
- [ ] I have searched [open](https://github.com/dlemstra/Magick.NET/issues) and [closed](https://github.com/dlemstra/Magick.NET/issues?q=is%3Aissue+is%3Aclosed) issues to ensure it has not already been reported

### Description

In a docker Linux container, .NET core 3.1.4, converting a SVG to PNG does not render correctly. But it does convert correctly in the Windows host.

### Steps to Reproduce

```sh
# dotnet ResizeMagick.NET.dll -i assets/person_svg.svg  -o assets/person_svg.png
```

### System Configuration
<!-- Tell us about the environment where you are experiencing the bug -->

- Magick.NET version: 7.15.5
- Environment (Operating system, version and so on): Debian GNU/Linux 10 (buster)

<!-- Thanks for reporting this issue to Magick.NET! -->
