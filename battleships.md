# Battleships Class Diagram by Abam

```mermaid

classDiagram
direction TB
    class Coordinate {
        X: int
        Y: int
    }

    class Ship {
        +ShipName name
        +int size
        -List~Coordinate~ _coordinates
        -List~Coordinate~ _hitPositions
        +Ship(ShipName name)
        +GetBlocksRemaining() List~Coordinate~
        +RecordHit(Coordinate hitCoordinate) void
        +IsSunk() bool
    }

    class ShipName {
        Destroyer
        Submarine
        Cruiser
        Battleship
        Carrier
    }

    class ShipFacing {
        ToLeft
        ToRight
        ToTop
        ToBottom
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
        -Board _board
        -string _name
        +Player(string name, Board board)
        +GetBoard() Board
    }

    class Board {
        -Cell~int,int~ _cell
        -int _size
        -List~Ship~ _ships
        +Board(int size, List~Ship~ ships)
        +GetSize() int
        +IsAllShipsSunk() bool
    }

    class AttackResult {
        Hit
        Miss
        Sunk
    }

    class Cell {
        bool isHit
        Ship currentShip
    }

    class GameController {
        -List~Player~ _players
        -List~Board~ _boards
        -Player _currentPlayer
        +int turn
        +Action~Player~ OnTurnChanged
        +Action~Player~ OnGameEnded
        +GameController(List~Player~ players, List~Board~ Boards)
        +PlaceShip(Ship ship, Board board, Coordinate startCoordinate, ShipFacing facing) void
        +StartGame() void
        +SwitchTurn() void
        +Attack(Player player, Board targetBoard, Coordinate coordinate) void
        +ReceiveAttack(Board receiverBoard, Coordinate coordinate) AttackResult
        +GetCoordinate(VerticalLabel verticalLabel, HorizontalLabel horizontalLabel) Coordinate
        +CheckWinner() Player
    }

    <<Enum>> ShipName
    <<Enum>> ShipFacing
    <<Enum>> AttackResult
    <<Enum>> VerticalLabel
    <<Enum>> HorizontalLabel

    Player *-- "1" Board
    Board *-- "0.." Ship
    Ship -- "1.." Coordinate
    GameController -- "2" Player
    ShipName --o Ship
    ShipFacing --o GameController
    AttackResult --o GameController
    Cell --* Board
```
