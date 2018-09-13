Module Module1
    Sub Main()
        Dim inp As String
        Console.Write("Enter exam result (0-100): ")
        inp = Integer.Parse(Console.ReadLine())

        'Flag prevents multiple grades from printing
        Dim flag As Boolean = False

        For i As Integer = 0 To 4
            '>80 = A, down 10% per grade
            If inp > (80 - (i * 10)) And Not flag Then
                Console.WriteLine("Your result is a " & Chr(65 + i) & ".")
                flag = True
            End If
        Next

        'If they didn't qualify for a grade.
        If Not flag Then
            Console.WriteLine("You failed.")
        End If

        Console.Write("any key to exit...")
        Console.ReadLine()
    End Sub
End Module
