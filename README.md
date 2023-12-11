# Text-Tolerator
A simple .NET library that creates a tolerated list of words or phrases that are considered similar to  the original text with the aim to ease text comparison in any .NET application.

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

## How It Works:

TextTolerator library produces text phrases that should be similar to the original supplied text and outputs them in a list that also includes the original input text.


Examples:
| **Input** |  Output  |  |  |  |  |  |
| :- | :-: | :-: | :-: | :-: | :-: | :-: | 
| **مدرسة** | مدرسة | المدرسة | مدرسه | المدرسه |  |  |
| **00447988 990011** | 00447988 990011 | +447988 990011 | 00447988990011 | +447988990011|  |  |
| **localize** | localize | Localize | LOCALIZE | localise | Localise | LOCALISE | 

### Creating TextToleratorEngine class:

The TextToleratorEngine class is responsible for the producing the out required output list of texts phrases from a supplied input text. To initiating it, a IRulesProvider class is needed, which provides the IRules to be used on the supplied input text.

There are two main IRulesProviders class that can be used:

1. ```GenericRulesProvider``` which loads all the IRule classes that adheres to a certain attribute, 

```CSharp
    //Loads all IRule classes with ArabicRuleAttribute
    var arabicRulesProvider = new GenericRulesProvider<ArabicRuleAttribute>();

    //Loads all IRule classes with PhoneNumberRuleAttribute
    var arabicRulesProvider = new GenericRulesProvider<PhoneNumberRuleAttribute>();

    //NOTE: Same way applies to EnglishRuleAttribute, WebsiteRuleAttribute and other attributes

```

2. ```FixedRulesProvider``` which loads only IRule classes specified at instantiation,

```Csharp
    //Loads only the specified IRule classes. ArabicAccentPolisherRule class in this case
    var fixedRulesProvider = new FixedRulesProvider(new ArabicAccentPolisherRule());

    //Loads the specified IRule classes
    var fixedRulesProvider = new FixedRulesProvider(new Website1WWWCleanerTogglerRule(), new Website2HttpCleanerTogglerRule());

```

3. Other customer IRuleProvider classes with custom way of loading IRule classes can be added by implementing IRuleProvider interface.


