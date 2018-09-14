Module Module1
    Function is_integer(inp As String)
        'The only characters a valid integer input should include
        Dim permissable_characters As String = "0123456789"

        'If an empty string is passed in, it's not an integer
        If inp = "" Then
            Return False
        End If

        'Checks each character in inp
        For Each letter In inp
            'If the character isn't in the charset
            If Not permissable_characters.Contains(letter) Then
                Return False
            End If
        Next
        Return True
    End Function

    Function get_integer_input()
        Console.Write("...")
        Dim out As String = Console.ReadLine()
        'Continually asks until the variable is a valid integer
        While Not is_integer(out)
            Console.Write("...")
            out = Console.ReadLine()
        End While
        Return Convert.ToInt64(out)
    End Function

    'Simple prompt, like Python's input("Prompt") function
    Function prompt(inp As String)
        Console.WriteLine(inp)
        Return get_integer_input()
    End Function

    Sub Main()
        'Loop until a valid pair of integers is inputted
        Dim looping As Boolean = True
        Dim maxMarks As Integer
        Dim marks As Integer
        While looping
            marks = prompt("Enter the marks you got:")
            maxMarks = prompt("Enter how many marks there were in total: ")
            If maxMarks > marks Then
                looping = False
            End If
        End While
        Console.WriteLine()

        'Finding the percentage

        Dim perc As Double = (marks / maxMarks) * 100

        'Removes all decimal places past the second
        perc = perc - (perc Mod 0.01)

        'If perc is an integer, convert it to one
        If perc = perc Mod 1 And perc >= 1 Then
            perc = Convert.ToInt16(perc)
        End If

        'Flag to prevent multiple grades from printing
        Dim alreadyGraded As Boolean = False

        For i As Integer = 0 To 4
            '>80 = A, down 10% per grade
            If perc > (80 - (i * 10)) And Not alreadyGraded Then
                Console.WriteLine("Your percentage is " & perc & " which is a" & {" ", "n "}(Convert.ToInt16(i = 0 Or i = 4)) & Chr(65 + i) & "!")
                alreadyGraded = True
            End If
        Next

        'If they didn't qualify for a grade.
        If Not alreadyGraded Then
            Console.WriteLine("Your percentage is " & perc & "%")
            Console.WriteLine("You failed.")
        End If

        Console.WriteLine()
        Console.Write("press <enter> to exit...")
        Console.ReadLine()
    End Sub
End Module
