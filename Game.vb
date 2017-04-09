' Rasmus Appelqvist
' 09/01-15
' Project: Snake

Option Explicit On
Option Strict On

''' <summary>
''' This class will handle all game logic
''' </summary>
''' <remarks></remarks>
Public Class Game
    Private mMainForm As MainForm
    Private mMap As Map
    Private mPlayer As Player
    Private mFood As Sprite
    Private mScore As Integer

    ''' <summary>
    ''' Return or set the score
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Score As Integer
        Get
            Return mScore
        End Get
        Set(value As Integer)
            mScore = value
        End Set
    End Property

    ''' <summary>
    ''' Initialize the game
    ''' </summary>
    ''' <param name="pMainForm">The parent main form</param>
    ''' <remarks></remarks>
    Public Sub New(pMainForm As MainForm)
        mMainForm = pMainForm

        mMap = New Map()
        Reset()
    End Sub

    ''' <summary>
    ''' Reset the game
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Reset()
        mScore = 0
        mPlayer = New Player(My.Resources.snake_head, New Point(9, 9), Me)
        MoveFood()
    End Sub

    ''' <summary>
    ''' Draw the game
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Draw(e As PaintEventArgs)
        mMap.Draw(e)
        mFood.Draw(e)
        mPlayer.Draw(e)

        ' Draw the score text
        e.Graphics.DrawString(
            "Score: " + mScore.ToString(),
            New Font("Arial", 14),
            New SolidBrush(Color.White),
            New Point(10, 10))
    End Sub

    ''' <summary>
    ''' Update the game
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Update()
        mPlayer.Update()
    End Sub

    ''' <summary>
    ''' Handle key down events
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub KeyDown(e As KeyEventArgs)
        mPlayer.KeyDown(e)
    End Sub

    ''' <summary>
    ''' Move the food to a new location
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveFood()
        Dim possibleTiles As List(Of Point) = New List(Of Point)

        ' Find available locations
        ' Iterate ALL tiles on the map
        For i As Integer = 0 To Map.MAPHEIGHT - 1
            For j As Integer = 0 To Map.MAPWIDTH - 1
                Dim pos As Point = New Point(i, j)

                ' Make sure that the tile is not a wall, a snake head or a snake tail
                If (Map.IsWalkable(pos) And Not mPlayer.IsTailAtPos(pos) And Not (mPlayer.Position.Equals(pos))) Then
                    possibleTiles.Add(pos)
                End If
            Next
        Next

        ' If a possible tile was found
        If (possibleTiles.Count > 0) Then
            Randomize()
            Dim foodImgs As Image() = {My.Resources.food1, My.Resources.food2, My.Resources.food3, My.Resources.food4}

            'Find a random image and a random available position
            mFood = New Sprite(foodImgs(CInt((foodImgs.Length - 1) * Rnd())), possibleTiles(CInt((possibleTiles.Count - 1) * Rnd())))
        Else
            ' If no possible tile was found, end the game
            GameOver()
        End If
    End Sub

    ''' <summary>
    ''' Check if the player is colliding with a wall, itself or food
    ''' </summary>
    ''' <returns>If food was eaten</returns>
    ''' <remarks></remarks>
    Public Function CheckPlayerPosition() As Boolean
        Dim foodAtPos As Boolean = mPlayer.Position.Equals(mFood.Position)
        Dim obstacleAtPos As Boolean = (Not Map.IsWalkable(mPlayer.Position) Or (mPlayer.IsTailAtPos(mPlayer.Position)))

        If (obstacleAtPos) Then
            ' If the player is colliding with a obstacle, end the game
            GameOver()
        ElseIf (foodAtPos) Then
            ' If the player is colliding with a food, eat the food
            MoveFood()
            mScore = mScore + 1
        End If

        Return foodAtPos
    End Function

    ''' <summary>
    ''' Tell the parent main form that the game is over
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GameOver()
        mMainForm.GameOver()
    End Sub
End Class
