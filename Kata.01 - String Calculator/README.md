# Kata.01 - String Calculator (via [Roy Osherove](http://osherove.com/tdd-kata-1/))
The following is a TDD Kata - an exercise in coding, refactoring and test-first, that you should apply daily for at least 15 minutes.

### Before you start: 
* Try not to read ahead.
* Do one task at a time. The trick is to learn to work incrementally.
* Make sure you only test for **correct inputs**. There is no need to test for invalid inputs for this kata.

## String Calculator:
1. Create a simple String calculator with a method `int Add(string numbers)`:
    1. The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example `""` or `"1"` or `"1,2"`.
    2. Start with the simplest test case of an empty string and move to 1 and two numbers.
    3. Remember to solve things as simply as possible so that you force yourself to write tests you did not think about.
    4. Remember to refactor after each passing test.
2. Allow the `Add` method to handle an unknown amount of numbers.
3. Allow the `Add` method to handle new lines between numbers (instead of commas).
    * The following input is OK:  `"1\n2,3"`  (will equal 6)
    * The following input is NOT OK:  `"1,\n"` (not need to prove it - just clarifying)
4. Support different delimiters:
    1. To change a delimiter, the beginning of the string will contain a separate line that looks like this: `"//[delimiter]\n[numbers...]"` for example `"//;\n1;2"` should return three where the default delimiter is `;`.
    2. The first line is optional. All existing scenarios should still be supported.
5. Calling `Add` with a negative number will throw an exception `"negatives not allowed"` - and the negative that was passed. If there are multiple negatives, show all of them in the exception message.
6. **Stop here if you are a beginner.** Continue if you can finish the steps so far in less than 30 minutes.
7. Numbers bigger than 1000 should be ignored, so adding `"2,1001"` should return `2`.
8. Delimiters can be of any length with the following format: `"//[delimiter]\n"`.
    * For example: `"//[***]\n1***2***3"` should return `6`.
9. Allow multiple delimiters like this: `"//[delim1][delim2]\n"` for example `"//[*][%]\n1*2%3"` should return `6`.
    * Make sure you can also handle multiple delimiters with length longer than one char.

----
# My thoughts:

As you may see, I made this TDD Kata (steps from *1* to *5*) in almost 2 hours. It was my first time, when I was playing with a truly approach of TDD.

* A initial commit [[2015-02-05 16:31:10 +0100: 2ae695](https://github.com/DominikJaniec/CodeKatasTDD/commit/2ae69540cc07379bc394f04e7de61421dd1d6ab1)]
* A green stage of 5th point [[2015-02-05 18:18:52 +0100: 69f7ae](https://github.com/DominikJaniec/CodeKatasTDD/commit/69f7aeff9d3d58e07d112da636bf27bbbaa1cb55)]

A next day afterwards, I wanted to continue this Kata. Maybe it isn't right way under this Kata, but I was feeling it would be very easy to finish these last three steps. I didn't remember why, but I only did a single step (7) and it took me up to 15 minutes.

* Work started on step [[2015-02-06 15:17:47 +0100: 5f53f6](https://github.com/DominikJaniec/CodeKatasTDD/commit/5f53f66440a056b5f40ad761c776829af4f958b4)]
* Step finished [[2015-02-06 15:32:22 +0100: a1fc4f](https://github.com/DominikJaniec/CodeKatasTDD/commit/a1fc4fa2fa2e86d4435e391b53ad8803682be0d6)]

In the end I finished work on these last two steps in about 50 minutes.

* First Monday commit [[2015-02-09 14:42:30 +0100: 5a2829](https://github.com/DominikJaniec/CodeKatasTDD/commit/5a282958173bd89a16c3bfdf145d1f192ddacdff)]
* Completing a kata [[2015-02-09 15:32:50 +0100: acc9fd](https://github.com/DominikJaniec/CodeKatasTDD/commit/acc9fd5e6097db13470583a2ab19d1309eb5ec66)] 

Ok, it wasn't a short 15 minutes play. Maybe it's that, I was committing all steps. Maybe because I was making it a first time.

But, I would like to make this Kata again. Probably I will use [nx]Unit, or something, but now I don't know. Also I will commit everything for create a history, like now.
