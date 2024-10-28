The main branch is just a line of changes, where each commit changes the program to show the different "features".
Each commit was tagged with a number 0-N for easy showing next change in the meeting by the followin CLI command

``` ps
> $index = 0
> $index = $index + 1 && git checkout $index 
``` 
Then the last line could be repeated untill the end.


97f5050 (tag: 15) RefCount Example!
f69f35f (tag: 14) Published RefCount Easy example
6598320 (tag: 13) Published ConnectedObservable example
da859f6 (tag: 12) Deffered example
942e4ab (tag: 11) Lame attempt on making a debounced string value
0198825 (tag: 10) Buffer and Window
8a17a6d (tag: 9) Time interval generation
ac26a33 (tag: 8) Hot Observable
ea5b1e3 (tag: 7) Event Pattern
32ff1f7 (tag: 6) Enumerable conversion
08a4680 (tag: 5, exception/300_complete) Exception handling
d95288e (tag: 4, creational/0_basic) Task vs Observable
3f9f9f5 (tag: 3) Cold observable
0e9a7ac (tag: 2) Some simple Observable factories
6a678cd (tag: 1) Simple return
05f6545 (tag: 0) Init commit
