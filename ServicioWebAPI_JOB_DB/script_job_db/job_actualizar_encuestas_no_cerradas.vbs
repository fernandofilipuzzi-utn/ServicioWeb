Call LogEntry()

Sub LogEntry()

	On Error Resume Next
	
	Dim objRequest
	Dim URL
	
	Set objRequest = CreateObject("Microsoft.XMLHTTP")
	URL = "https://localhost:44376/api/ProcesarEncuestas"
	
	objRequest.open "GET", URL, false
	objRequest.Send
	
	Set objRequest = Nothing
	

End Sub