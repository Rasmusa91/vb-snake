' Rasmus Appelqvist
' 09/01-15
' Project: Snake

Option Explicit On
Option Strict On

''' <summary>
''' This class will be parent to all, handling main menu, end menu and the game itself
''' </summary>
''' <remarks></remarks>
Public Class MainForm
    Private mGame As Game
    Private mIsRunning As Boolean

    ''' <summary>
    ''' Initialize the form
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        mGame = New Game(Me)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitializeGui()
    End Sub

    ''' <summary>
    ''' This method will initialize the gui
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeGui()
        ' Make gameplay smoother
        Me.SetStyle(ControlStyles.DoubleBuffer _
                    Or ControlStyles.UserPaint _
                    Or ControlStyles.AllPaintingInWmPaint, _
     True)

        ' Hide the game over screen
        endScreenGroupBox.Visible = False
    End Sub

    ''' <summary>
    ''' This method will handle a game over method
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GameOver()
        mIsRunning = False
        endScreenGroupBox.Visible = True
        endScreenScoreLabel.Text = "Score: " + mGame.Score.ToString()
    End Sub

    ''' <summary>
    ''' This event will let us draw on the canvas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        mGame.Draw(e)

        ' If the game is not running, show a transparent black overlay
        If Not (mIsRunning) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.Black)), New Rectangle(0, 0, Map.MAPWIDTH * Map.TILESIZE, Map.MAPHEIGHT * Map.TILESIZE))
        End If
    End Sub

    ''' <summary>
    ''' This event will let all components in the game it's time to update the logic
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GameLoop_Tick(sender As Object, e As EventArgs) Handles GameLoop.Tick
        ' Only update if the game is running
        If (mIsRunning) Then
            mGame.Update()

            ' Tell the canvas to redraw
            Refresh()
        End If
    End Sub

    ''' <summary>
    ''' This event will let the components know a key is being pressed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Only register the events if the game is running
        If (mIsRunning) Then
            mGame.KeyDown(e)
        End If
    End Sub

    ''' <summary>
    ''' This event will check if the start button in the main form has been clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        ' Hide the main form
        mainGroupBox.Visible = False

        ' Start the game
        mGame.Reset()
        mIsRunning = True
        Me.Focus()
    End Sub

    ''' <summary>
    ''' THis event will check if the exit button in the main menu has been pressed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        ' Close the form
        Me.Close()
    End Sub

    ''' <summary>
    ''' This event will check if the restart button on the end screen has been pressed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub restartButton_Click(sender As Object, e As EventArgs) Handles restartButton.Click
        ' Hide the end screen group box
        endScreenGroupBox.Visible = False

        'Restart the game
        mGame.Reset()
        mIsRunning = True
        Me.Focus()
    End Sub

    ''' <summary>
    ''' This event will check if the return button on the end screen has been pressed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click
        ' Hide the endscreen form
        endScreenGroupBox.Visible = False

        ' Show the main group form
        mainGroupBox.Visible = True
    End Sub
End Class
