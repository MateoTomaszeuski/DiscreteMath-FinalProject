# Discrete Math Final Project: Exercise 19,3.4


# A:
To show that there at most 16 cosets of H in G, for any N x N board,
we are going to use induction to prove that any configuration of marbes can be reduced to a configration
where there are marbles only in the 2x2 low right corner.

## Inductive Step:
Assume a board size n-1 x n-1 can be reduced to a configuration where there are marbles only in the 2x2 low right corner.
Now we are going to show that a board size n x n, by adding elements of H, we can cancel out our marbles in the first board.
Doing this, we reduce the board leaving only the marbles in the las row and column.
Adding elements of H again, we can reduce the board to a configuration where there are marbles only in the 2x2 low right corner.

# B:
In the 2x2 configurations, we label the diagonals followwing the given schemes, we need to show any configurations that satisfy the condition
a ≡ b ≡ c  mod 2.
The only configuration that satisfies the previos condition is the empty configuration.
So we can say that the empty configuration is the only element of H.

# C:
As now we know that the only element of H is the empty configuration,
we understand that the given 10x10 board , only by adding elements of H,
and the desired configuration with only one marble in the 2x2 low right corner,
we understand that the desired configuration is not an element of H making it impossible to reach.

# D:
To make the puzzle solvable, we have to change the starting configuration, or the size, to be elements of H.
if we start with a configuration that is already an element of H, we can reach the desired configuration.
The other solution is to change the size of the board to be an element of H, so we can reach the desired configuration.

## Example:
starting board:
0 0 0
0 0 0
0 0 0

moves:
1. Jump the middle marble of the top row over the bottom marble of the top row.
2. Jump the middle marble of the bottom row over the top marble of the bottom row.
3. Continue with similar moves until one marble is left.

Final:
X X X
X X X
X X 0
```
