
Module ModGlobalFunctions


    Function GetID() As String

        For i As Integer = 0 To Now.Millisecond
            Rnd()
        Next

        Dim IDMix As String = System.Environment.MachineName + System.Environment.UserDomainName + System.Environment.UserName + Now.ToLongDateString + Now.ToLongTimeString + Rnd().ToString

        Return GetSHA256HashString(IDMix)

    End Function

    Function GetAccountID(ByVal PublicKeyHEX As String) As ULong
        Dim PubKeyAry() As Byte = HEXStringToByteArray(PublicKeyHEX)
        Dim SHA256 As System.Security.Cryptography.SHA256Managed = New System.Security.Cryptography.SHA256Managed()
        PubKeyAry = SHA256.ComputeHash(PubKeyAry)
        Return BitConverter.ToUInt64(PubKeyAry, 0) '{PubKeyAry(0), PubKeyAry(1), PubKeyAry(2), PubKeyAry(3), PubKeyAry(4), PubKeyAry(5), PubKeyAry(6), PubKeyAry(7)}, 0)
    End Function
    Function GetAccountRS(ByVal PublicKeyHEX As String) As String
        Return ClsReedSolomon.Encode(GetAccountID(PublicKeyHEX))
    End Function
    Function GetAccountRSFromID(ByVal AccountID As ULong) As String
        Return ClsReedSolomon.Encode(AccountID)
    End Function
    Function GetAccountIDFromRS(ByVal AccountRS As String) As ULong
        Return ClsReedSolomon.Decode(AccountRS)
    End Function

    Function RandomBytes(ByVal Length As Integer) As Byte()

        Dim rnd As Random = New Random
        Dim b(Length) As Byte
        rnd.NextBytes(b)

        Return b

    End Function

    Function MessageIsHEXString(ByVal Message As String) As Boolean

        If Message.Length Mod 2 <> 0 Then
            Return False
        End If

        Dim CharAry() As Char = Message.ToUpper.ToCharArray

        For Each Chr As Char In CharAry
            Select Case Chr
                Case "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c
                Case Else
                    Return False
            End Select

        Next

        Return True

    End Function


    Function IsNumber(ByVal Input As String) As Boolean

        Dim CharAry() As Char = Input.ToUpper.ToCharArray

        For Each Chr As Char In CharAry
            Select Case Chr
                Case "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c
                Case Else
                    Return False
            End Select

        Next

        Return True

    End Function

    Function IsReedSolomon(ByVal RSString As String) As Boolean

        If Not RSString.Length = 20 Then
            Return False
        End If

        Dim CharAry() As Char = RSString.ToUpper.ToCharArray

        For Each Chr As Char In CharAry
            Select Case Chr
                Case "-"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "J"c, "K"c, "L"c, "M"c, "N"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c
                Case Else
                    Return False
            End Select

        Next

        Return True
    End Function

End Module