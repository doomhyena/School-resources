## Task
We use the integers **a**, **b**, and **n** to create the following series:

For each query, print the series corresponding to the given **a**, **b**, and **n** values as a single line of space-separated integers.

## Input Format
- The first line contains an integer, **q**, denoting the number of queries.
- Each of the next **q** lines contains three space-separated integers describing the respective **a**, **b**, and **n** values for that query.

## Constraints
- **0 ≤ a, b ≤ 50**
- **1 ≤ n ≤ 15**
- **1 ≤ q ≤ 500**

## Output Format
For each query, print the corresponding series on a new line. Each series must be printed in order as a single line of space-separated integers.

## Sample Input
```
2
0 2 10
5 3 5
```

## Sample Output
```
2 6 14 30 62 126 254 510 1022 2046
8 14 26 50 98
```

## Explanation
We have two queries:

1. Using **a = 0**, **b = 2**, and **n = 10**, we generate the series:
   ```
   2 6 14 30 62 126 254 510 1022 2046
   ```
2. Using **a = 5**, **b = 3**, and **n = 5**, we generate the series:
   ```
   8 14 26 50 98
   ```

Each series is printed as a single line of space-separated integers.

