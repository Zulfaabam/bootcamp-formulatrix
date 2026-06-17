# Battleships Class Diagram by Abam

```mermaid

classDiagram
direction TB
    class Coordinate {
        X: int
        Y: int
    }

    class Ship {
        +ShipType Type
        +int Size
        +ShipOrientation Orientation
        +Ship(ShipType type)
        +IsSunk() bool
    }

    class ShipOrientation {
        Vertical
        Horizontal
    }

    class ShipType {
        Destroyer
        Submarine
        Cruiser
        Battleship
        Carrier
    }

    class VerticalLabel {
        A
        B
        C
        ...
        H
    }

    class HorizontalLabel {
        1
        2
        3
        ...
        8
    }

    class Player {
        +string Name
        +Player(string name)
    }

    class Board {
        -Cell[,] _cell
        +int Size
        +Board(int size)
        +GetSize() int
    }

    class AttackResult {
        Hit
        Miss
        Sunk
    }

    class Cell {
        -Ship? _currentShip
        +bool IsHit
        +Coordinate Coordinate
        +AttackResult? AttackResult
    }

    class GameController {
        -List~Player~ _players
        -List~Board~ _boards
        -Dictionary<.Player, Board> _playerBoard
        -Dictionary<.Board, List<.Ship>> _shipsOnBoard
        +int Turn
        +Player CurrentPlayer
        +Action~Player~ OnGameEnded
        +GameController(List~Player~ players, List~Board~ Boards)
        +StartGame() void
        -PlaceShip(Player player, Ship ship, Coordinate startCoordinate, Coordinate endCoordinate) void
        -SwitchTurn() void
        -Attack(Player player, Board targetBoard, Coordinate coordinate) void
        -ReceiveAttack(Board receiverBoard, Coordinate coordinate) AttackResult
        -GetCoordinate(VerticalLabel verticalLabel, HorizontalLabel horizontalLabel) Coordinate
        -IsAllShipsOnBoardSunk(Board, board) bool
        +CheckWinner() Player
    }

    <<Enum>> ShipType
    <<Enum>> AttackResult
    <<Enum>> VerticalLabel
    <<Enum>> HorizontalLabel
    <<Enum>> ShipOrientation

    Player *-- "1" Board
    Board *-- "0.." Ship
    Ship -- "1.." Coordinate
    GameController <.. "2" Player
    GameController <.. Board
    GameController <.. Ship
    ShipType --o Ship
    ShipOrientation --o Ship
    AttackResult --o GameController
    AttackResult --o Cell
    Cell --* Board
```
