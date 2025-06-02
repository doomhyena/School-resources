Java's `System.out.printf` function can be used to print formatted output. The purpose of this exercise is to test your understanding of formatting output using `printf`.

To get you started, a portion of the solution is provided for you in the editor; you must format and print the input to complete the solution.

## Input Format
Each line of input will contain a **String** followed by an **integer**.

- Each **String** will have a maximum of **10** alphabetic characters.
- Each **integer** will be in the inclusive range from **0 to 999**.

## Output Format
Each line of output should contain two columns:

1. The first column contains the **String** and is **left-justified** using exactly **15** characters.
2. The second column contains the **integer**, expressed in exactly **3** digits; if the original input has less than three digits, you must **pad** the leading digits with zeroes.

The output should be enclosed within a border of `=` characters at the top and bottom.

## Sample Input
```
java 100
cpp 65
python 50
```

## Sample Output
```
================================
java           100
cpp            065
python         050
================================
```

## Explanation
- Each **String** is left-justified with trailing whitespace to ensure it occupies **15** characters.
- Each **integer** is formatted to always have **3 digits**, with leading zeroes added when necessary.

