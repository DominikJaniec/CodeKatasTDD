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

## First time, with test execution engine from Visual Studio:
Branch: [**`Kata01_StringCalculator_msTest`**](https://github.com/DominikJaniec/CodeKatasTDD/tree/Kata01_StringCalculator_msTest)

As you may see, I made this TDD Kata (steps from *1* to *5*) in almost 2 hours. It was my first time, when I was playing with a truly approach of TDD:

  * A initial commit: 2015-02-05 16:31:10 +0100 [[`2ae6954`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/2ae69540cc07379bc394f04e7de61421dd1d6ab1)
  * A green stage of 5th point: 2015-02-05 18:18:52 +0100 [[`69f7aef`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/69f7aeff9d3d58e07d112da636bf27bbbaa1cb55)

A next day afterwards, I wanted to continue this Kata. Maybe it isn't right way under this Kata, but I was feeling it would be very easy to finish these last three steps. I didn't remember why, but I only did a single step (*7*) and it took me up to 15 minutes:

  * Work started on step: 2015-02-06 15:17:47 +0100 [[`5f53f66`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/5f53f66440a056b5f40ad761c776829af4f958b4)
  * Step finished: 2015-02-06 15:32:22 +0100 [[`a1fc4fa`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/a1fc4fa2fa2e86d4435e391b53ad8803682be0d6)

In the end I finished work on these last two steps in about 50 minutes:

  * First Monday commit: 2015-02-09 14:42:30 +0100 [[`5a28295`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/5a282958173bd89a16c3bfdf145d1f192ddacdff)
  * Completing a kata: 2015-02-09 15:32:50 +0100 [[`acc9fd5`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/acc9fd5e6097db13470583a2ab19d1309eb5ec66)

Ok, it wasn't a short 15 minutes play. Maybe it's that, I was committing all steps - with distinction for **Red** and **Green** phase. Maybe because I was making it a first time.

## Second approach, now with help from xUnit library:
Branch: [**`Kata01_StringCalculator_xUnit`**](https://github.com/DominikJaniec/CodeKatasTDD/tree/Kata01_StringCalculator_xUnit)

This time I was working on this Kata in three time spans:

  1. From 2015-10-20 16:01:41 +0200: [[`7b911e0`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/7b911e069e01c9eb64b2662ed7c160fadec7678e) to about 1.5 hour later: [[`d70916c`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/d70916cac32d98cd06b414a3474c888382a6024d)
       * Everything here looks good, with rather normally speed of work.
       * Done first four steps with only one larger gap (40 minutes) before last commit.
       * I stopped on defining custom delimiters, because I understood that delimiter can by any length, not only single char - so I didn't keep [**YAGNI**](https://en.wikipedia.org/wiki/You_aren%27t_gonna_need_it) principle in my mind, so I used Regex for that purpose... ([*I know, I'll use regular expressions.* Now you have two problems](http://programmers.stackexchange.com/questions/223634/what-is-meant-by-now-you-have-two-problems))
  2. From 2015-10-21 10:41:31 +0200: [[`490906e`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/490906e418171f40a1b116aff72be912de07dd7e) to about 3 hours later: [[`4953110`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/495311030bc33571c2c7f7bcfa4e250bd46b1b8b)
       * Everything was going OK, until Regex strike back again ;)
       * A first problematic change comes from fact, that when delimiter has been defined, and it is longer then single char, then also it should has been wrapped with: `[`, `]` symbols. That step took about 30 minutes of work: [[`854b4ee`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/854b4ee164434a45171fa0da1d49619caa6e7d84).
       * Before my last commit (which looks like about 2h work, but an circa 40 minutes was my lunch break) I was changing Regex to handle definition of multiple delimiters and again, I'm not sure that with different approach I could done it more clean, fast or correct.
  3. From 2015-10-21 17:09:26 +0200: [[`1eabb87`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/1eabb87e576eb814c0fb5be5ce02f16a12ee1a23) to about 2 hours later: [[`81baf50`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/81baf50bbef3c0262defca3f12489415baf98c30)
       * Works here was rather small bug fixing, or clean-up with an one hour break in middle.


Total time taken: nearly **5 hours** over *two days*... Something went wrong, didn't it? I'm not sure what was the true cause, maybe Regex, maybe myself, maybe too frequented committing to git.

But I had done this Kata one more time, in one, continuous activity. The first five steps I made in about 38 minutes and stop, like 6th point claims: _"(...) Continue if you can finish the steps so far in less than 30 minutes"_. Here it is: [**`Kata01_StringCalculator_oneTrial`**](https://github.com/DominikJaniec/CodeKatasTDD/tree/Kata01_StringCalculator_oneTrial).


Last time [[`000249b`]](https://github.com/DominikJaniec/CodeKatasTDD/commit/000249b66339046fb718f3a3979c2aaa64de6497), when I was writing in this README, I wrote that I will make this Kata using [nx]Unit's library instead Asserts provided by Visual Studio. So I have done it with xUnit. Actually I don't see any huge differences, but probably third party Asserts library is better than strict binds to Visual Studio.
