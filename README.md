# DirSize

<a href="https://coderpro.net" target="_blank"><img src="https://coderpro.net/media/1024/coderpro_logo_rounded_extra-90x90.webp" align="right" width="90" /></a>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Twitter](https://img.shields.io/twitter/url/https/twitter.com/cloudposse.svg?style=social&label=Follow%20%40coderProNet)](https://twitter.com/coderProNet)
[![GitHub](https://img.shields.io/github/followers/coderpros?label=Follow&style=social)](https://github.com/coderpros)

[contributors-shield]: https://img.shields.io/github/contributors/coderpros/DirSize.svg?style=flat-square
[contributors-url]: https://github.com/coderpros/DirSize/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/coderpros/DirSize?style=flat-square
[forks-url]: https://github.com/coderpros/DirSize/network/members
[stars-shield]: https://img.shields.io/github/stars/coderpros/DirSize.svg?style=flat-square
[stars-url]: https://github.com/coderpros/DirSize/stargazers
[issues-shield]: https://img.shields.io/github/issues/coderpros/DirSize?style=flat-square
[issues-url]: https://github.com/coderpros/DirSize/issues
[license-shield]: https://img.shields.io/github/license/coderpros/DirSize?style=flat-square
[license-url]: https://github.com/coderpros/DirSize/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/company/coderpros
[twitter-shield]: https://img.shields.io/twitter/follow/coderpronet?style=social
[twitter-follow-url]: https://img.shields.io/twitter/follow/coderpronet?style=social
[github-shield]: https://img.shields.io/github/followers/coderpros?label=Follow&style=social
[github-follow-url]: https://img.shields.io/twitter/follow/coderpronet?style=social

> Powershell function that recursively returns directory sizes.

## Usage
> DirSize.ps1 -Path "C:\path_to_analyze" [-Detailed] [-Mb]
> > -Detailed recursively returns all sub directories.
> > 
> > -Mb returns filesizes in Mb instead of Gb

# DirSize.Console
> .Net 5 C# Console application that recursively returns directory sizes. 

## Usage
> DirSize [drive:][path] [/v] [/MB]
> > /v Verbose. Recursive breakdown of each directory.
> > /? Returns man doc.
> > /MB Returns results in megabytes.
        
## Change Log
* 2021/10/20:
  * Added console application. 
* 2021/10/17: 
  * Project creation / initial checkin.
  * Added optional -Mb parameter that will force the script to return filesizes in Mb instead of Gb.

## Notes
