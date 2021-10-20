<a href="https://coderpro.net" target="_blank"><img src="https://scontent.fuio1-1.fna.fbcdn.net/v/t1.6435-9/79833047_3479965898710673_564625832480342016_n.png?_nc_cat=102&ccb=1-5&_nc_sid=09cbfe&_nc_ohc=3Nx5DZMlfXMAX9Lxw8K&tn=q01BnXEWZpJcTBLv&_nc_ht=scontent.fuio1-1.fna&oh=d9e08604ea4f691a25b0af25912ebf4e&oe=61669F4F" align="right" width="90" /></a>


[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Twitter](https://img.shields.io/twitter/url/https/twitter.com/cloudposse.svg?style=social&label=Follow%20%40coderProNet)](https://twitter.com/coderProNet)
[![GitHub](https://img.shields.io/github/followers/coderpros?label=Follow&style=social)](https://github.com/coderpros)

# CoderPro.DirSize

A [KickBox.io](https://kickbox.io) API wrapper for Classic ASP.

## How to use

- Create a free account at [Kickbox.io](https://kickbox.io).
- Sign up for an API Key.
- Update the KICKBOX_API_KEY constant in ~/Includes/config.asp file to use your API Key.

### Verify a single email address

```vbs
Dim KickBox: Set KickBox = New KickBoxObject
Dim verificationResponse

With KickBox
    .ClientApiKey = KICKBOX_API_KEY
    Set verificationResponse = .VerifySingleEmail(string emailAddress))
End With
```

### Verify multiple email addresses

```vbs
Dim KickBox: Set KickBox = New KickBoxObject
Dim verificationResponse

With KickBox
    .ClientApiKey = KICKBOX_API_KEY
    Set verificationResponse = .VerifyBulkEmail(string emailAddressesSeparatedByNewline))
End With
```

### Check status of a bulk verification job

```vbs
Dim KickBox: Set KickBox = New KickBoxObject
Dim verificationResponse

With KickBox
    .ClientApiKey = KICKBOX_API_KEY
    Set verificationResponse = .CheckVerificationStatus(int JobId)
End With
```

*~/Default.asp is a functional example of how to use this library.*

# Change Log
- 2021/12/10: Initial Checkin

[contributors-shield]: https://img.shields.io/github/contributors/coderpros/CoderPro.DirSize.svg?style=flat-square
[contributors-url]: https://github.com/coderpros/CoderPro.DirSize/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/coderpros/CoderPro.DirSize?style=flat-square
[forks-url]: https://github.com/coderpros/CoderPro.DirSize/network/members
[stars-shield]: https://img.shields.io/github/stars/coderpros/CoderPro.DirSize.svg?style=flat-square
[stars-url]: https://github.com/coderpros/CoderPro.DirSize/stargazers
[issues-shield]: https://img.shields.io/github/issues/coderpros/CoderPro.DirSize?style=flat-square
[issues-url]: https://github.com/coderpros/CoderPro.DirSize/issues
[license-shield]: https://img.shields.io/github/license/coderpros/CoderPro.DirSize?style=flat-square
[license-url]: https://github.com/coderpros/CoderPro.DirSize/master/blog/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/company/coderpros
[twitter-shield]: https://img.shields.io/twitter/follow/coderpronet?style=social
[twitter-follow-url]: https://img.shields.io/twitter/follow/coderpronet?style=social
[github-shield]: https://img.shields.io/github/followers/coderpros?label=Follow&style=social
[github-follow-url]: https://img.shields.io/twitter/follow/coderpronet?style=social
