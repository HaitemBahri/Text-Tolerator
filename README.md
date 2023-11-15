# Text-Tolerator
A simple .NET library that creates a tolerated list of words or phrases that are considered similar to  the original text with the aim to ease text comparison in any .NET application.

Examples:
| **Input** |  Output  |  |  |  |  |  |
| :- | :-: | :-: | :-: | :-: | :-: | :-: | 
| **مدرسة** | مدرسة | المدرسة | مدرسه | المدرسه |  |  |
| **00447988 990011** | 00447988 990011 | +447988 990011 | 00447988990011 | +447988990011|  |  |
| **localize** | localize | Localize | LOCALIZE | localise | Localise | LOCALISE | 

## The Problem
Some text words, although different, are considered the same by users and often used interchangeably. This creates a problem for users of some applications that involves text input when users use words interchangeably thinking that they are the same while applications treat them as being different words.

One case where this might create an issue is with search tools. In an application where users can search for data stored earlier, the exact spelling must be provided in order for the application to lookup the required data. If a different variation in text is used in either the stored text or the supplied search text, the search inquiry will fail, ending up with 0 results. 

This problem is more frequent in some languages than others. For example in Arabic some letters are used interchangeably as if they are the same. Some examples of similar letters are:
- Ta'a Marbuta ( **ة** ) 
- Ha'a ( **ه** ) 

Another example:
- Alif w/ humza on top ( **أ** ) 
- Alif ( **ا** ) 
- Alif w/ humza underneath ( **إ** ) 

Although these letter might be considered similar because of shape or pronunciation, there have different unicode values and thus are treated differently by digital devices.

Example of arabic words that are considered the same:
- ( **قلعة** ) & ( **قلعه** )
- ( **أقلام** ) & ( **اقلام** )
- ( **أقنعة** ), ( **أقنعه** ), ( **اقنعة** ) & ( **اقنعه** )

This problem can also appear in english text and number-based text like phone number, although not frequent. Examples are:
- ( **color** ) & ( **colour** )
- ( **+218 (21) 4559911** ), ( **00218 (21) 4559911** ), ( **+218 21 4559911** ) & ( **00218 21 4559911** )
- ( **google.com** ), ( **www.google.com** ) & ( **https://www.google.com** ) 


