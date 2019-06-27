# JobSequenceSolution
On the Beach Code Test:

The Challenge
Imagine we have a list of jobs, each represented by a character. Because certain jobs must be done before others, a job may have a
dependency on another job. For example, a may depend on b, meaning the final sequence of jobs should place b before a. If a has no
dependency, the position of a in the final sequence does not matter.

# Scenarios:

1. Given you’re passed an empty string (no jobs), the result should be an empty sequence.

2. Given the following job structure:
a=>
The result should be a sequence consisting of a single job a.

3. Given the following job structure:
a =>
b =>
c =>
The result should be a sequence containing all three jobs abc in no significant order.

4. Given the following job structure:
a =>
b => c
c =>
The result should be a sequence that positions c before b, containing all three jobs abc.

5. Given the following job structure:
a =>
b => c
c => f
d => a
e => b
f =>
The result should be a sequence that positions f before c, c before b, b before e and a before d containing all six jobs abcdef.


6. Given the following job structure:
a =>
b =>
c => c
The result should be an error stating that jobs can’t depend on themselves.

7. Given the following job structure:
a =>
b => c
c => f
d => a
e =>
f => b
The result should be an error stating that jobs can’t have circular dependencies.

# Solution
The given problem can be resolved using topological sorting technique.
1. first the jobs with no depedency and add it in a dictionary
2. find the jobs which has dependency and add it in a dictionary
3. arrange the dependent job in sequene
4. find if any cyclic dependency is there are not in a seprate list from the job dictionary data, if so throw exception
5. find if any self dependecy is available .. if so throw exception.


# How to run?
1. Run the application
2. Enter the number of job structure
3. Enter each job and their depedency line by line
Sample input:
Enter number of job structure
6
Enter 6 job structure each in 1 line
(Ex: if job 'a' depends on job 'b' then enter as a=>b. if job 'a' doesn't depends on any job simply enter a=>)
a =>
b => c
c => f
d => a
e => b
f =>

Sample Output:
a,f,d,c,b,e
