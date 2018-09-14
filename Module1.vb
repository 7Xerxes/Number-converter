Module Module1
    Sub Main()
        Dim inp As String
        Console.Write("Enter the marks you got: ")
        Dim marks As Integer = Convert.ToInt32(Console.ReadLine())
        Console.Write("Enter how many marks there were: ")
        Dim maxMarks As Integer = Convert.ToInt32(Console.ReadLine())
        Dim perc As Double = (marks / maxMarks) * 100

        'Removes all decimal places past the second
        perc = perc - (perc Mod 0.01)

        'If perc is an integer, convert it to one
        If perc = perc Mod 1 And perc >= 1 Then
            perc = Convert.ToInt16(perc)
        End If

        'Flag prevents multiple grades from printing
        Dim flag As Boolean = False

        For i As Integer = 0 To 4
            '>80 = A, down 10% per grade
            If perc > (80 - (i * 10)) And Not flag Then
                Console.WriteLine("Your result is a " & Chr(65 + i) & ". " & "Percentage is " & perc & "%")
                flag = True
            End If
        Next

        'If they didn't qualify for a grade.
        If Not flag Then
            Console.WriteLine("Your percentage is " & perc & "%")
            Console.WriteLine("You failed.")
        End If

        Console.Write("...")
        Console.ReadLine()
    End Sub
End Module
