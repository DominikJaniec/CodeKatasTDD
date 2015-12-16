# Kata.02 - Roman Numerals (via [Giorgio Sironi](https://dzone.com/articles/roman-numerals-kata-tdd-and))

[*From Wikipedia* - Roman numerals](https://en.wikipedia.org/wiki/Roman_numerals), as used today, are based on seven symbols:

| Symbol | Value  |
| -----: | :------|
|   `I`  |  1     |
|   `V`  |  5     |
|   `X`  |  10    |
|   `L`  |  50    |
|   `C`  |  100   |
|   `D`  |  500   |
|   `M`  |  1000  |

Numbers are formed by combining symbols and adding the values, so `II` is two (two ones) and `XIII` is thirteen (a ten and three ones). There is no zero in this system and characters do not represent tens, hundreds and so on according to position as in 207 or 1066; those numbers are written as `CCVII` (two hundreds, a five and two ones) and `MLXVI` (a thousand, a fifty, a ten, a five and a one).

Symbols are placed from left to right in order of value, starting with the largest. However, in a few specific cases, to avoid four characters being repeated in succession (such as `IIII` or `XXXX`), subtractive notation is often used as follows:

  * `I` placed before `V` or `X` indicates one less, so four is `IV` (one less than five) and nine is `IX` (one less than ten)
  * `X` placed before `L` or `C` indicates ten less, so forty is `XL` (ten less than fifty) and ninety is `XC` (ten less than a hundred)
  * `C` placed before `D` or `M` indicates a hundred less, so four hundred is `CD` (a hundred less than five hundred) and nine hundred is `CM` (a hundred less than a thousand)

For example, `MCMIV` is one thousand nine hundred and four, 1904 (`M` is a thousand, `CM` is nine hundred and `IV` is four).

----
# My thoughts:

## First time, straightforward approach:
Branch: [**`Kata02_RomanNumerals_First`**](https://github.com/DominikJaniec/CodeKatasTDD/tree/Kata02_RomanNumerals_First)

This Kata passed very light for me. I had started from very easy way:

  * Just return `I` [[`1ae6084`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/1ae608437f76fc3bdb17f356f825d193cced00c8 ).
  * Just return _x times_ `I` [[`0c1b4c9`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/0c1b4c95535ff532c66fa5e2de614c0f7af5818a ).
  * Try to not return more then _3 times_ [[`6439d6a`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/6439d6a1114275098e71697bb309876c16c7f743 ).

And it's took me a little more then 10 minutes.

Next 20 minutes I spend on handling numbers up to 5. I used a _translation map_ and _subtraction_ to achieve translation from Arabic representation to Roman [[`a823e83`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/a823e83ca25c0d3fd83c1c8c23d24f536f01388a ). Probably before, somewhere on internet, I saw this approach and as far as I know this is "the best" - I will explain this later.

Then, it's look like, that I had spent 30 minutes on adding next 10 rows in _translation map_, but probably I was looking for _Test Samples_ [[`b805f9d`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/b805f9df7263baf28d27e4337f40464a82946e34 ).

Thereafter, I had tried refactor code to (branch: [**`Kata02_RomanNumerals_Fail`**](https://github.com/DominikJaniec/CodeKatasTDD/tree/Kata02_RomanNumerals_Fail)):

  * _Translations map_ contains only **base** symbols
  * Employ rule: _"do not repeat a symbol more then 3 times"_
  * Work with sequences, by: `yield return something;`

But I abandoned it... Like I wrote in commit message [[`5aed51d`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/5aed51d1d82e63aa98f0f3fd7d19e2ec123e8a3d ). This is why I believe that approach based on _translation map_ with special cases (4, 9 and theirs 10 multiples) is "the best". Because that way is simple, and contains _repetition rule_ (mentioned above).
