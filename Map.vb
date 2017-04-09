' Rasmus Appelqvist
' 09/01-15
' Project: Snake

Option Explicit On
Option Strict On

''' <summary>
''' This class will handle the map of the game (environment)
''' </summary>
''' <remarks></remarks>
Public Class Map
    ' Simulate a direction
    Public Enum Direction
        Down
        Up
        Left
        Right
    End Enum
    Public Shared DirectionRelation As Dictionary(Of Direction, Point) = New Dictionary(Of Direction, Point) From {{Direction.Up, New Point(0, -1)},
                                                                                                                    {Direction.Down, New Point(0, 1)},
                                                                                                                    {Direction.Right, New Point(1, 0)},
                                                                                                                    {Direction.Left, New Point(-1, 0)}}
    ' Create some size constants
    Public Const TILESIZE = 32
    Public Const MAPWIDTH = 20
    Public Const MAPHEIGHT = 20

    Private mEnvironment As List(Of Sprite)

    ''' <summary>
    ''' Initialize the map
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        mEnvironment = New List(Of Sprite)

        Generate()
    End Sub

    ''' <summary>
    ''' Generate all environment of the map
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Generate()
        ' Iterate all possible tiles
        For i As Integer = 0 To MAPHEIGHT - 1
            For j As Integer = 0 To MAPWIDTH - 1
                ' Put grass everywhere
                mEnvironment.Add(New Sprite(My.Resources.grass, New Point(i, j)))

                ' Put a wall on the unwalkable tiles
                If (Not IsWalkable(New Point(i, j))) Then
                    mEnvironment.Add(New Sprite(GetRandomWallImage(), New Point(i, j)))
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' Draw the map
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Draw(e As PaintEventArgs)
        For Each environment As Sprite In mEnvironment
            environment.Draw(e)
        Next
    End Sub

    ''' <summary>
    ''' Check if a position is walkable
    ''' </summary>
    ''' <param name="pPosition">THe position to be checked</param>
    ''' <returns>If the position is walkable</returns>
    ''' <remarks></remarks>
    Public Shared Function IsWalkable(pPosition As Point) As Boolean
        ' The edges is unwalkable
        Return Not (pPosition.X = 0 Or pPosition.X = MAPHEIGHT - 1 Or pPosition.Y = 0 Or pPosition.Y = MAPWIDTH - 1)
    End Function

    ''' <summary>
    ''' Get a random wall image
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRandomWallImage() As Image
        Randomize()

        Dim img As Image = Nothing

        Select Case CInt(1 * Rnd())
            Case 0
                img = My.Resources.wall1
            Case 1
                img = My.Resources.wall2
        End Select

        Return img
    End Function

    ''' <summary>
    ''' Find the opposite direction of a given direction
    ''' </summary>
    ''' <param name="pDirection">The direction to be opposited</param>
    ''' <returns>The opposited direction</returns>
    ''' <remarks></remarks>
    Public Shared Function GetOppositeDirection(pDirection As Direction) As Direction
        Dim dir As Direction = Direction.Down

        If (pDirection = Direction.Down) Then
            dir = Direction.Up
        ElseIf (pDirection = Direction.Left) Then
            dir = Direction.Right
        ElseIf (pDirection = Direction.Right) Then
            dir = Direction.Left
        End If

        Return dir
    End Function
End Class
