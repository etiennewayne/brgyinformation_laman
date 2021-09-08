﻿Imports MySql.Data.MySqlClient

Public Class Resident

    Public Property IsHead As Integer
    Public Property HouseHoldNo As String
    Public Property FamilyNo As String
    Public Property Lname As String
    Public Property Fname As String
    Public Property Mname As String
    Public Property Suffix As String
    Public Property Sex As String
    Public Property CiviStatus As String
    Public Property BirthDate As String
    Public Property Religion As String
    Public Property Nationality As String
    Public Property EmploymentStatus As String
    Public Property Occupation As String
    Public Property AnnualIncome As String

    Public YearResidence As String



    Public Function Save() As Integer

        Dim i As Integer = 0
        Try
            conOpen()
            query = "INSERT INTO residents SET " &
                "is_head = @ishead, " &
                "household_no = @household_no, family_no = @family_no, lname = @lname, fname = @fname, mname = @mname, " &
                "suffix = @suffix, sex = @sex, civil_status = @cstatus, religion = @religion, nationality = @nationality, " &
                "employment_status = @employment, occupation = @occupation, annual_income = @annual_income, year_residence = @yr_residence"
            cmd = New MySqlCommand(query, con)
            With cmd.Parameters
                .AddWithValue("@ishead", Me.IsHead)
                .AddWithValue("@household_no", Me.HouseHoldNo)
                .AddWithValue("@family_no", Me.FamilyNo)
                .AddWithValue("@lname", Me.Lname)
                .AddWithValue("@fname", Me.Fname)
                .AddWithValue("@mname", Me.Mname)
                .AddWithValue("@suffix", Me.Suffix)
                .AddWithValue("@sex", Me.Sex)
                .AddWithValue("@cstatus", Me.CiviStatus)
                .AddWithValue("@bdate", Me.BirthDate)
                .AddWithValue("@religion", Me.Religion)
                .AddWithValue("@nationality", Me.Nationality)
                .AddWithValue("@employment", Me.EmploymentStatus)
                .AddWithValue("@occupation", Me.Occupation)
                .AddWithValue("@annual_income", Me.AnnualIncome)
                .AddWithValue("@yr_residence", Me.YearResidence)
            End With
            i = cmd.ExecuteNonQuery
            cmd.Dispose()
            conClose()

            Return i
        Catch ex As Exception
            ErrBox(ex.Message)

            Return 0
        End Try

    End Function

    Public Function Update(ByVal id As Integer) As Integer
        Dim i As Integer = 0
        Try
            conOpen()
            query = "UPDATE residents SET" &
                "household_no = @household_no, family_no = @family_no, lname = @lname, @fname  = @fname, mname = @mname," &
                "suffix = @suffix, sex = @sex, civil_status = @cstatus, religion = @religion, nationality = @nationality," &
                "employment_status = @employment, @occupation = @occupation, @annual_income = @annual_income, @year_residence = @yr_residence WHERE resident_id = @id"
            cmd = New MySqlCommand(query, con)
            With cmd.Parameters
                .AddWithValue("@household_no", Me.HouseHoldNo)
                .AddWithValue("@family_no", Me.FamilyNo)
                .AddWithValue("@lname", Me.Lname)
                .AddWithValue("@fname", Me.Fname)
                .AddWithValue("@mname", Me.Mname)
                .AddWithValue("@suffix", Me.Suffix)
                .AddWithValue("@sex", Me.Sex)
                .AddWithValue("@cstatus", Me.CiviStatus)
                .AddWithValue("@bdate", Me.BirthDate)
                .AddWithValue("@religion", Me.Religion)
                .AddWithValue("@nationality", Me.Nationality)
                .AddWithValue("@employment", Me.EmploymentStatus)
                .AddWithValue("@occupation", Me.Occupation)
                .AddWithValue("@annual_income", Me.AnnualIncome)
                .AddWithValue("@yr_residence", Me.YearResidence)
                .AddWithValue("@id", id)
            End With
            i = cmd.ExecuteNonQuery
            cmd.Dispose()
            conClose()

            Return i
        Catch ex As Exception
            ErrBox(ex.Message)

            Return 0
        End Try
    End Function

    Public Function Delete(ByVal id As Integer) As Integer
        Dim i As Integer = 0
        Try
            conOpen()
            query = "DELETE FROM residents WHERE resident_id = @id"
            cmd = New MySqlCommand(query, con)
            With cmd.Parameters
                .AddWithValue("@id", id)
            End With
            i = cmd.ExecuteNonQuery
            cmd.Dispose()
            conClose()

            Return i
        Catch ex As Exception
            ErrBox(ex.Message)
            Return 0
        End Try
    End Function

    Public Sub All(ByVal grid As DataGridView)
        Try
            conOpen()
            query = "SELECT * FROM residents ORDER BY lname ASC"
            cmd = New MySqlCommand(query, con)
            Dim dt As New DataTable
            Dim adprtr As New MySqlDataAdapter(cmd)
            adprtr.Fill(dt)
            adprtr.Dispose()
            cmd.Dispose()

            grid.AutoGenerateColumns = False
            grid.DataSource = dt

        Catch ex As Exception
            ErrBox(ex.Message)
        End Try
    End Sub

End Class
