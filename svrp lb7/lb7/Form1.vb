Public Class Form1
    Private a, b, c, d As Double
    Private paper As Graphics
    Private mypen As Pen = New Pen(Color.Black)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        paper = PictureBox1.CreateGraphics()
        DrawGraph()
    End Sub
    Private Sub DrawGraph()
        a = CDbl(TextBox1.Text)
        b = CDbl(TextBox2.Text)
        c = CDbl(TextBox3.Text)
        d = CDbl(TextBox4.Text)
        paper.Clear(Color.White)
        Draw()
    End Sub
    Private Sub Draw()
        Dim x, y, nextX, nextY As Double
        Dim xpixel, ypixel, nextxpixel, nextypixel As Integer
        For xpixel = 0 To PictureBox1.Width
            x = ScaleX(xpixel)
            y = TheFunction(x)
            ypixel = ScaleY(y)
            nextxpixel = xpixel + 1
            nextX = ScaleX(nextxpixel)
            nextY = TheFunction(nextX)
            nextypixel = ScaleY(nextY)
            paper.DrawLine(mypen, xpixel, ypixel, nextxpixel, nextypixel)
        Next
        Dim font1 As New Font("Colibri", 10)
        Dim brush1 As New SolidBrush(Color.Black)
        Dim a1 As Integer
        a1 = 0
        Dim a As Integer = 0
        For i = -5 To 5 Step 1
            paper.DrawString(i, font1, brush1, a, PictureBox1.Height / 2)
            a = a + 29
        Next
        a = 0
        For i = 5 To -5 Step -1
            If i <> 0 Then
                paper.DrawString(i, font1, brush1, PictureBox1.Width / 2, a)
            End If
            a = a + 28
        Next
        paper.DrawLine(mypen, 0, CInt(283 / 2), 283, CInt(283 / 2))
        paper.DrawLine(mypen, CInt(283 / 2), 283, CInt(283 / 2), 0)
    End Sub



    Private Function TheFunction(ByVal x As Double) As Double
        Return a * x * x * x + b * x * x + c * x + d
    End Function
    Private Function ScaleX(ByVal xpixel As Integer) As Double
        Dim xstart As Double = -5, xend As Double = 5
        Dim xscale As Double = PictureBox1.Width / (xend - xstart)
        Return (xpixel - (PictureBox1.Width / 2)) / xscale
    End Function
    Private Function ScaleY(ByVal y As Double) As Integer
        Dim ystart As Double = -5, yend As Double = 5
        Dim pixelcoord As Integer
        Dim yscale As Double = PictureBox1.Height / (yend - ystart)
        pixelcoord = CInt(-y * yscale) + CInt(PictureBox1.Height / 2)
        Return pixelcoord
    End Function
End Class
