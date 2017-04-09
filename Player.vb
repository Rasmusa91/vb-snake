' Rasmus Appelqvist
' 09/01-15
' Project: Snake

Option Explicit On
Option Strict On

''' <summary>
''' This class will handle the logic of a player
''' </summary>
''' <remarks></remarks>
Public Class Player
    Inherits Sprite

    Private mGame As Game
    Private mTimer As Stopwatch
    Private mDirection As Map.Direction
    Private mTail As List(Of Sprite)

    ''' <summary>
    ''' Initialize the player
    ''' </summary>
    ''' <param name="pImage">The image of the player</param>
    ''' <param name="pPosition">The initial position of the player</param>
    ''' <param name="pGame">The parent game handeler</param>
    ''' <remarks></remarks>
    Public Sub New(pImage As Image, pPosition As Point, pGame As Game)
        MyBase.New(pImage, pPosition)

        mGame = pGame

        mTimer = New Stopwatch()
        mTimer.Start()

        mTail = New List(Of Sprite)

        SetDirection(Map.Direction.Left)

        'Add 2 parts of the tail initially
        Dim addPos = Map.DirectionRelation(Map.GetOppositeDirection(mDirection))
        mTail.Add(New Sprite(My.Resources.snake_body, New Point(Position.X + addPos.X, Position.Y + addPos.Y)))
        mTail.Add(New Sprite(My.Resources.snake_body, New Point(Position.X + addPos.X * 2, Position.Y + addPos.Y * 2)))
    End Sub

    ''' <summary>
    ''' Update the player
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Update()
        ' Every .5 seconds, auto-move
        If (mTimer.ElapsedMilliseconds > 500) Then
            mTimer.Restart()
            Move()
        End If
    End Sub

    ''' <summary>
    ''' Draw the player
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Overrides Sub Draw(e As PaintEventArgs)
        MyBase.Draw(e)

        ' Draw the tail
        For Each item As Sprite In mTail
            item.Draw(e)
        Next
    End Sub

    ''' <summary>
    ''' Handle a key down
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub KeyDown(e As KeyEventArgs)
        If (e.KeyCode = Keys.W Or e.KeyCode = Keys.Up) Then
            ' Move up
            SetDirection(Map.Direction.Up)
        ElseIf (e.KeyCode = Keys.S Or e.KeyCode = Keys.Down) Then
            ' Move down
            SetDirection(Map.Direction.Down)
        ElseIf (e.KeyCode = Keys.A Or e.KeyCode = Keys.Left) Then
            ' Move left
            SetDirection(Map.Direction.Left)
        ElseIf (e.KeyCode = Keys.D Or e.KeyCode = Keys.Right) Then
            ' Move right
            SetDirection(Map.Direction.Right)
        End If
    End Sub

    ''' <summary>
    ''' Move the player
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Move()
        ' Put the last part of the tail on the position of the head
        Dim temp As Sprite = mTail(mTail.Count - 1)
        temp.Position = Position

        ' Move the last element of the tail in the list to the first element
        mTail.Remove(temp)
        mTail.Insert(0, temp)

        ' Find the new position of the snake
        Dim addPos = Map.DirectionRelation(mDirection)
        Position = New Point(Position.X + addPos.X, Position.Y + addPos.Y)

        ' Check the new position of the player
        If (mGame.CheckPlayerPosition()) Then
            ' If food was eaten, add a copy of the last tail item
            mTail.Add(New Sprite(mTail(mTail.Count - 1)))
        End If
    End Sub

    ''' <summary>
    ''' Set the direction of the snake
    ''' </summary>
    ''' <param name="pDirection"></param>
    ''' <remarks></remarks>
    Public Sub SetDirection(pDirection As Map.Direction)
        Dim dirPos As Point = New Point(0, 0)

        ' Find the direction of the first tail item (IF there is one)
        If (mTail.Count > 0) Then
            dirPos = mTail(0).Position
        End If

        ' Make sure that the new direction is not facing the first tail item
        If Not Map.DirectionRelation(pDirection).Equals(New Point(dirPos.X - Position.X, dirPos.Y - Position.Y)) Then
            ' Make sure that the old direction is not the same as the new direction
            If Not mDirection = pDirection Then
                mDirection = pDirection

                ' Rotate the image accordingly
                If (mDirection = Map.Direction.Down) Then
                    RotateImage(RotateFlipType.Rotate270FlipNone)
                ElseIf (mDirection = Map.Direction.Up) Then
                    RotateImage(RotateFlipType.Rotate90FlipNone)
                ElseIf (mDirection = Map.Direction.Left) Then
                    RotateImage(RotateFlipType.RotateNoneFlipNone)
                ElseIf (mDirection = Map.Direction.Right) Then
                    RotateImage(RotateFlipType.Rotate180FlipNone)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Check if a given position is the same as a tail item
    ''' </summary>
    ''' <param name="pPosition"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsTailAtPos(pPosition As Point) As Boolean
        Dim isAtPos As Boolean = False

        ' Iterate all tail items and compare the position
        For i As Integer = 0 To mTail.Count - 1
            If mTail(i).Position.Equals(pPosition) Then
                isAtPos = True
            End If
        Next

        Return isAtPos
    End Function
End Class
