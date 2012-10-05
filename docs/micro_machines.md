#Micro Machines

You have a table that serves as a 5*5 grid based track for a set of
micro machine cars.

For the purpose of this kata, assume we are only dealing with
one car on the track.

These micro machines have a limitation of only being able to move
ahead.

They do, however, respond to being rotated in either of the following
directions:

* Rotate Left
* Rotate Right

When a micro machine is provide a set of directions in the following
form:

Origin position of a car is facing north

"O(0,0),R,1,L,2,"

The location and rotation of the micro machine should be reflected
by movement on the track.

It is possible for a micro machine to be given a set of directions
that would cause it to be driven off the track. When a micro
machine falls of the track, its position should reflect the following
message:

* Fell off the track


