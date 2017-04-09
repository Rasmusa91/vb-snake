' Rasmus Appelqvist
' 09/01-15
' Project: Snake

Option Explicit On
Option Strict On

''' <summary>
''' This class will handle a sprite (image, position and rotation)
''' </summary>
''' <remarks></remarks>
Public Class Sprite
    Private mImage As Image
    Private mOrigImage As Image
    Private mPosition As Point

    ''' <summary>
    ''' Get or set the position of the sprite
    ''' </summary>
    ''' <value>The new position</value>
    ''' <returns>The position</returns>
    ''' <remarks></remarks>
    Property Position As Point
        Get
            Return mPosition
        End Get
        Set(value As Point)
            mPosition = value
        End Set
    End Property

    ''' <summary>
    ''' Initialize the sprite
    ''' </summary>
    ''' <param name="pImage">The image to be drawn</param>
    ''' <param name="pPosition">The tile position where to be drawn</param>
    ''' <remarks></remarks>
    Public Sub New(pImage As Image, pPosition As Point)
        mImage = New Bitmap(pImage)
        mOrigImage = New Bitmap(pImage)
        mPosition = pPosition
    End Sub

    ''' <summary>
    ''' Initialize the sprite with a copy of another sprite
    ''' </summary>
    ''' <param name="pSprite">The sprite to be copied from</param>
    ''' <remarks></remarks>
    Public Sub New(pSprite As Sprite)
        Me.New(pSprite.mImage, pSprite.Position)
    End Sub

    ''' <summary>
    ''' Draw the sprite
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Overridable Sub Draw(e As PaintEventArgs)
        ' Draw the given image on the tilePosition * tileSize
        e.Graphics.DrawImage(mImage, New Rectangle(mPosition.X * Map.TILESIZE, mPosition.Y * Map.TILESIZE, Map.TILESIZE, Map.TILESIZE))
    End Sub

    ''' <summary>
    ''' Rotate the image
    ''' </summary>
    ''' <param name="pRotation">The new rotation</param>
    ''' <remarks></remarks>
    Public Sub RotateImage(pRotation As RotateFlipType)
        'Reset the image
        mImage = New Bitmap(mOrigImage)

        'Rotate it
        mImage.RotateFlip(pRotation)
    End Sub
End Class
