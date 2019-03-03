Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Office.Interop

Public Class testObj

    Public name As String
    Public age As String
    Public location As String
    Public hobby As String
    Public dob As String
    Public color As String

End Class


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Service
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function CreateExcel() As String

        Dim rowCounter = 1

        Dim excelObjs As New List(Of testObj) From
            {
                New testObj With {.age = "10", .dob = "23/01/12", .hobby = "swimming", .location = "london", .name = "khan", .color = "black"},
                New testObj With {.age = "20", .dob = "13/01/15", .hobby = "boxing", .location = "Atlanta", .name = "Tom", .color = "yella"},
                New testObj With {.age = "44", .dob = "03/04/12", .hobby = "running", .location = "london", .name = "jack", .color = "orange"},
                New testObj With {.age = "16", .dob = "13/11/11", .hobby = "swimming", .location = "Birmingham", .name = "sarah", .color = "white"},
                New testObj With {.age = "3", .dob = "25/12/06", .hobby = "badminton", .location = "Texas", .name = "plum", .color = "red"}
            }


        Dim headers() As String = {"name", "age", "location", "hobby", "food", "color", "dob"}

        Dim fileTest As String = "C:\Users\Rahim\Desktop\test.xlsx"
        If File.Exists(fileTest) Then
            File.Delete(fileTest)
        End If

        'create an excel application the and worksheet with a workbook to be made on
        Dim oExcel As Object
        oExcel = CreateObject("Excel.Application")
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        Dim oSheet As Microsoft.Office.Interop.Excel.Worksheet
        oBook = oExcel.Workbooks.Add
        oSheet = oExcel.Worksheets(1)
        oSheet.Name = "Test Name"

        'loop through all the headers in the array and save to the csv (cells function does not accept 0 hence +1 value)
        For index As Integer = 0 To headers.Length - 1
            oSheet.Cells(rowCounter, index + 1) = headers(index)
        Next

        'style the header column
        With oSheet.Range("A1", "G1")
            .Font.Bold = True
            .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            .Style.IncludeBorder = True
            .Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Interior.ColorIndex = 37
        End With

        'loop through all the objects and save to the csv with their own styles
        For Each cell In excelObjs
            rowCounter += 1

            Dim properties = cell.GetType().GetProperties()
                For Each prop In properties
                    Console.WriteLine("{0}: {1}", prop.Name,
                    prop.GetValue(cell, New Object() {}))
                Next


                For counter As Integer = 0 To headers.Length - 1
                    oSheet.Cells(rowCounter, counter + 1) = cell.name
                    With oSheet.Cells(rowCounter, counter + 1)
                        .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    End With
                Next

        Next


        'For Each cell In excelObjs
        'rowCounter += 1
        'With cell
        'For counter As Integer = 0 To headers.Length - 1
        'oSheet.Cells(rowCounter, counter + 1) = cell.name
        'With oSheet.Cells(rowCounter, counter + 1)
        '.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        '.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        'End With
        'Next
        'End With
        'Next

        'save file and the garbage collect
        oBook.SaveAs(fileTest)
        oBook.Close()
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing

        Return "Hello World"



        'Dim fileTest As String = "C:\Users\Rahim\Desktop\test.xlsx"
        'If File.Exists(fileTest) Then
        'File.Delete(fileTest)
        'End If

        'Dim oExcel As Object
        'oExcel = CreateObject("Excel.Application")
        'Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        'Dim oSheet As Microsoft.Office.Interop.Excel.Worksheet

        'oBook = oExcel.Workbooks.Add
        'oSheet = oExcel.Worksheets(1)

        'oSheet.Name = "Test Name"
        'oSheet.Range("A1").Value = "SOME VALUE"
        'oSheet.Range("A2").Value = "SOME VALUE2"
        'oBook.SaveAs(fileTest)
        'oBook.Close()
        'oBook = Nothing
        'oExcel.Quit()
        'oExcel = Nothing   

        'With oSheet.Cells(1, 3)
        '.Font.Bold = False
        '.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        '.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        '.Style.IncludeBorder = False
        '.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        '.Interior.ColorIndex = 39
        'End With

    End Function

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()>
    Public Function GetDetails(name As String, age As Integer) As String
        Return String.Format("Name: {0}{2}Age: {1}{2}TimeStamp: {3}", name, age, Environment.NewLine, DateTime.Now.ToString())
    End Function

End Class