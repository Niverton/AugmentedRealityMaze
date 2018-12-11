# Implementation of a Maze Game on Unity
## Introduction

In the context of the course of Virtual and Augmented Reality (Réalité
virtuelle et réalité augmentée), we had to implement a game with a maze.
Our project is a maze on a board, controlled by the arrow keys. The goal
is to bring a rolling ball, representing the player, to the exit of the
maze. The exit is known and most of the difficulty is to manage to bring
the ball where we want to. We had this idea from a game of Roll-a-ball
we implemented a few weeks earlier and from wooden "Ball-in-a-maze
puzzles"

## Implementation

We use Unity because it has everything we need to implement quickly most
of the game features and possesses an easy-to-use interface to recognize
ArUco Markers.

The maze is generated randomly :
- We go from the starting position of the maze and make a path grow
  until we reach the exit.
- We then generate the other parts of the maze, ones that lead to a dead
  end.
- We remove a few walls to make the game easier so we have multiple ways
  to reach the end.

When the player gets closer to the end, the light grows larger, but when
going in the wrong direction, the lighting reduces and the player can
only see their surroundings anymore.  To move, the player can only
change the orientation of the board. The ball then rolls following the
gravity and the orientation of the board.

## Material

A computer or phone using the application.

If the ArUco part of the project is done :
- An ArUco Marker to move the board.
- A camera to see the marker.

## Limitations

One of the objectives was to have ArUco Markers control the direction of
the player through a camera capturing its orientation and the marker
acting as the game board. However this wasn't implemented due to a lack
of time.  
We can also add other features like some background music or noises to
indicate if the player is going in the right direction or not.
