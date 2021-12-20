"# TP_Unsta_Grupo_14_Obj3" 

Definición de roles 
Rol	Función
admin_sec	Administración de Seguridad. Permiso para dar de alta usuarios. No tiene permisos sobre las API Course
admin_plat	Administración de la Plataforma. Permite crear, actualizar y borrar (baja lógica) cursos y consultar un curso específico o listar los cursos que estén activos
user		Usuario. Puede consultar un curso específico o listar los cursos que estén activos.

Matriz de Roles/Funciones
Alta de Usuario			==>	admin_sec		
Ver datos de un curso	==> admin_plat	user
Listar cursos			==> admin_plat	user
Crear un curso			==>	admin_plat
Modificar un curso		==>	admin_plat	
Borrar un curso			==>	admin_plat	



Codigos de salida implementados
Code	Indicador
200		Openracion correcta
201		Elemento Creado
202		Operacion Aceptada / Para actualizacion de datos
401		Operacion no autorizada
404		No encontrado. Para operaciones de baja o modificacion. ID no registrado
500		Error en la operacion.


#######################
#  Usuario admin_sec  #
#######################
Una vez generado el token con Postman se verificaron las funciones:


Alta de Usuario:
================

curl -X 'POST' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/admin/altaUsr/{myUser}' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDMyNTc0LCJuYmYiOjE2NDAwMzI1NzQsImV4cCI6MTY0MDAzNjc1NSwiYWNyIjoiMSIsImFpbyI6IkUyWmdZSkJJdWNVWEVsMDNUNzE1K3VMYVdTOTJ2Ykh1cTJlNnl2eDRuazNEZVFQSExpRUEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJzZWd1cmlkYWQiLCJnaXZlbl9uYW1lIjoiYWRtaW5pc3RyYWRvciIsImlwYWRkciI6IjE4Ni4xMzYuMTM4LjcxIiwibmFtZSI6ImFkbWluX3NlYyIsIm9pZCI6Ijk0ZDkxNDc0LWY5YjktNDc2My1hMjBkLWE0ODYzOWRlMTM2NiIsInJoIjoiMC5BVVlBa181M2U2elBEVUNja0NjQ1N1SW15S2h4R0xaZGtfOUd0VHhvc09zaThKS0FBTjguIiwicm9sZXMiOlsiYWRtaW5fc2VjIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiejIxbDEtMHJNME10TlZkTmhaeFozR2E3Y3NkQlhyekRPbno1YWhWQWZMWSIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoiYWRtaW5fc2VjQGFhZHVuc3RhdHAxNC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbl9zZWNAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IlZJR3lNRmhGbUV5WC10cjNDZjQzQUEiLCJ2ZXIiOiIxLjAifQ.nayLNqinjjMCvmYK3VNZPSKoowtJAshmJrCu5dvz8-uKqjmj4Ey8fk7AvQ5FtAzOK-VcJG3Gk808frEKsm6SMp1QFOSAClv0JhBdw3KsxslPejBOHfptEp6KJH1_Xo3bktIpplW3MIUmYcGktZ9xx7Sjf6E5vsMOJFc7dBL1_DJy0m1oZoUYN8ruphFaDPE1LoLwDaqz5d2ZSjWQMaYcBWceObk5S9NJw0nRCZ9CHUAJB2Hs_-ze5ZtpIlgE5VBLR-1ExU7JH8gAnJOsoSQyAuS7qsE-Rly0gJgOxpILQgED70upSEqi2oOwsOuJ5Lr3tu7b1vyqorXPb5j_HCCn0g' \
  -H 'Content-Type: application/json' \
  -d '{
  "firstName": "Bill",
  "lastName": "Gates",
  "password": "qweASD123.",
  "rol": "user"
}'

Server response
Code	Details
200		Response body 


Listado de Cursos:
==================

curl -X 'GET' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDMyNTc0LCJuYmYiOjE2NDAwMzI1NzQsImV4cCI6MTY0MDAzNjc1NSwiYWNyIjoiMSIsImFpbyI6IkUyWmdZSkJJdWNVWEVsMDNUNzE1K3VMYVdTOTJ2Ykh1cTJlNnl2eDRuazNEZVFQSExpRUEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJzZWd1cmlkYWQiLCJnaXZlbl9uYW1lIjoiYWRtaW5pc3RyYWRvciIsImlwYWRkciI6IjE4Ni4xMzYuMTM4LjcxIiwibmFtZSI6ImFkbWluX3NlYyIsIm9pZCI6Ijk0ZDkxNDc0LWY5YjktNDc2My1hMjBkLWE0ODYzOWRlMTM2NiIsInJoIjoiMC5BVVlBa181M2U2elBEVUNja0NjQ1N1SW15S2h4R0xaZGtfOUd0VHhvc09zaThKS0FBTjguIiwicm9sZXMiOlsiYWRtaW5fc2VjIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiejIxbDEtMHJNME10TlZkTmhaeFozR2E3Y3NkQlhyekRPbno1YWhWQWZMWSIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoiYWRtaW5fc2VjQGFhZHVuc3RhdHAxNC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbl9zZWNAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IlZJR3lNRmhGbUV5WC10cjNDZjQzQUEiLCJ2ZXIiOiIxLjAifQ.nayLNqinjjMCvmYK3VNZPSKoowtJAshmJrCu5dvz8-uKqjmj4Ey8fk7AvQ5FtAzOK-VcJG3Gk808frEKsm6SMp1QFOSAClv0JhBdw3KsxslPejBOHfptEp6KJH1_Xo3bktIpplW3MIUmYcGktZ9xx7Sjf6E5vsMOJFc7dBL1_DJy0m1oZoUYN8ruphFaDPE1LoLwDaqz5d2ZSjWQMaYcBWceObk5S9NJw0nRCZ9CHUAJB2Hs_-ze5ZtpIlgE5VBLR-1ExU7JH8gAnJOsoSQyAuS7qsE-Rly0gJgOxpILQgED70upSEqi2oOwsOuJ5Lr3tu7b1vyqorXPb5j_HCCn0g'

Code	Details
401		Undocumented Error: Unauthorized


Datos del Curso 1:
==================
curl -X 'GET' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/1' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDMyNTc0LCJuYmYiOjE2NDAwMzI1NzQsImV4cCI6MTY0MDAzNjc1NSwiYWNyIjoiMSIsImFpbyI6IkUyWmdZSkJJdWNVWEVsMDNUNzE1K3VMYVdTOTJ2Ykh1cTJlNnl2eDRuazNEZVFQSExpRUEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJzZWd1cmlkYWQiLCJnaXZlbl9uYW1lIjoiYWRtaW5pc3RyYWRvciIsImlwYWRkciI6IjE4Ni4xMzYuMTM4LjcxIiwibmFtZSI6ImFkbWluX3NlYyIsIm9pZCI6Ijk0ZDkxNDc0LWY5YjktNDc2My1hMjBkLWE0ODYzOWRlMTM2NiIsInJoIjoiMC5BVVlBa181M2U2elBEVUNja0NjQ1N1SW15S2h4R0xaZGtfOUd0VHhvc09zaThKS0FBTjguIiwicm9sZXMiOlsiYWRtaW5fc2VjIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiejIxbDEtMHJNME10TlZkTmhaeFozR2E3Y3NkQlhyekRPbno1YWhWQWZMWSIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoiYWRtaW5fc2VjQGFhZHVuc3RhdHAxNC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbl9zZWNAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IlZJR3lNRmhGbUV5WC10cjNDZjQzQUEiLCJ2ZXIiOiIxLjAifQ.nayLNqinjjMCvmYK3VNZPSKoowtJAshmJrCu5dvz8-uKqjmj4Ey8fk7AvQ5FtAzOK-VcJG3Gk808frEKsm6SMp1QFOSAClv0JhBdw3KsxslPejBOHfptEp6KJH1_Xo3bktIpplW3MIUmYcGktZ9xx7Sjf6E5vsMOJFc7dBL1_DJy0m1oZoUYN8ruphFaDPE1LoLwDaqz5d2ZSjWQMaYcBWceObk5S9NJw0nRCZ9CHUAJB2Hs_-ze5ZtpIlgE5VBLR-1ExU7JH8gAnJOsoSQyAuS7qsE-Rly0gJgOxpILQgED70upSEqi2oOwsOuJ5Lr3tu7b1vyqorXPb5j_HCCn0g'

Code	Details
401 	Undocumented Error: Unauthorized


Borrar curso 5:
===============

curl -X 'DELETE' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/5' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDMyNTc0LCJuYmYiOjE2NDAwMzI1NzQsImV4cCI6MTY0MDAzNjc1NSwiYWNyIjoiMSIsImFpbyI6IkUyWmdZSkJJdWNVWEVsMDNUNzE1K3VMYVdTOTJ2Ykh1cTJlNnl2eDRuazNEZVFQSExpRUEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJzZWd1cmlkYWQiLCJnaXZlbl9uYW1lIjoiYWRtaW5pc3RyYWRvciIsImlwYWRkciI6IjE4Ni4xMzYuMTM4LjcxIiwibmFtZSI6ImFkbWluX3NlYyIsIm9pZCI6Ijk0ZDkxNDc0LWY5YjktNDc2My1hMjBkLWE0ODYzOWRlMTM2NiIsInJoIjoiMC5BVVlBa181M2U2elBEVUNja0NjQ1N1SW15S2h4R0xaZGtfOUd0VHhvc09zaThKS0FBTjguIiwicm9sZXMiOlsiYWRtaW5fc2VjIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiejIxbDEtMHJNME10TlZkTmhaeFozR2E3Y3NkQlhyekRPbno1YWhWQWZMWSIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoiYWRtaW5fc2VjQGFhZHVuc3RhdHAxNC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbl9zZWNAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IlZJR3lNRmhGbUV5WC10cjNDZjQzQUEiLCJ2ZXIiOiIxLjAifQ.nayLNqinjjMCvmYK3VNZPSKoowtJAshmJrCu5dvz8-uKqjmj4Ey8fk7AvQ5FtAzOK-VcJG3Gk808frEKsm6SMp1QFOSAClv0JhBdw3KsxslPejBOHfptEp6KJH1_Xo3bktIpplW3MIUmYcGktZ9xx7Sjf6E5vsMOJFc7dBL1_DJy0m1oZoUYN8ruphFaDPE1LoLwDaqz5d2ZSjWQMaYcBWceObk5S9NJw0nRCZ9CHUAJB2Hs_-ze5ZtpIlgE5VBLR-1ExU7JH8gAnJOsoSQyAuS7qsE-Rly0gJgOxpILQgED70upSEqi2oOwsOuJ5Lr3tu7b1vyqorXPb5j_HCCn0g'

Code	Details
401		Undocumented Error: Unauthorized


Agregar de curso:
=================

curl -X 'POST' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/{course}' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDMyNTc0LCJuYmYiOjE2NDAwMzI1NzQsImV4cCI6MTY0MDAzNjc1NSwiYWNyIjoiMSIsImFpbyI6IkUyWmdZSkJJdWNVWEVsMDNUNzE1K3VMYVdTOTJ2Ykh1cTJlNnl2eDRuazNEZVFQSExpRUEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJzZWd1cmlkYWQiLCJnaXZlbl9uYW1lIjoiYWRtaW5pc3RyYWRvciIsImlwYWRkciI6IjE4Ni4xMzYuMTM4LjcxIiwibmFtZSI6ImFkbWluX3NlYyIsIm9pZCI6Ijk0ZDkxNDc0LWY5YjktNDc2My1hMjBkLWE0ODYzOWRlMTM2NiIsInJoIjoiMC5BVVlBa181M2U2elBEVUNja0NjQ1N1SW15S2h4R0xaZGtfOUd0VHhvc09zaThKS0FBTjguIiwicm9sZXMiOlsiYWRtaW5fc2VjIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiejIxbDEtMHJNME10TlZkTmhaeFozR2E3Y3NkQlhyekRPbno1YWhWQWZMWSIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoiYWRtaW5fc2VjQGFhZHVuc3RhdHAxNC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbl9zZWNAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IlZJR3lNRmhGbUV5WC10cjNDZjQzQUEiLCJ2ZXIiOiIxLjAifQ.nayLNqinjjMCvmYK3VNZPSKoowtJAshmJrCu5dvz8-uKqjmj4Ey8fk7AvQ5FtAzOK-VcJG3Gk808frEKsm6SMp1QFOSAClv0JhBdw3KsxslPejBOHfptEp6KJH1_Xo3bktIpplW3MIUmYcGktZ9xx7Sjf6E5vsMOJFc7dBL1_DJy0m1oZoUYN8ruphFaDPE1LoLwDaqz5d2ZSjWQMaYcBWceObk5S9NJw0nRCZ9CHUAJB2Hs_-ze5ZtpIlgE5VBLR-1ExU7JH8gAnJOsoSQyAuS7qsE-Rly0gJgOxpILQgED70upSEqi2oOwsOuJ5Lr3tu7b1vyqorXPb5j_HCCn0g' \
  -H 'Content-Type: application/json' \
  -d '{
  "courseid": 0,
  "nombre": "string",
  "descripcion": "string",
  "precio": 0,
  "activo": true,
  "fecha": "2021-12-20T20:55:54.266Z"
}'

Code	Details
401		Undocumented Error: Unauthorized


Modificar curso 5:
==================

curl -X 'PUT' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/{course}' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDMyNTc0LCJuYmYiOjE2NDAwMzI1NzQsImV4cCI6MTY0MDAzNjc1NSwiYWNyIjoiMSIsImFpbyI6IkUyWmdZSkJJdWNVWEVsMDNUNzE1K3VMYVdTOTJ2Ykh1cTJlNnl2eDRuazNEZVFQSExpRUEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJzZWd1cmlkYWQiLCJnaXZlbl9uYW1lIjoiYWRtaW5pc3RyYWRvciIsImlwYWRkciI6IjE4Ni4xMzYuMTM4LjcxIiwibmFtZSI6ImFkbWluX3NlYyIsIm9pZCI6Ijk0ZDkxNDc0LWY5YjktNDc2My1hMjBkLWE0ODYzOWRlMTM2NiIsInJoIjoiMC5BVVlBa181M2U2elBEVUNja0NjQ1N1SW15S2h4R0xaZGtfOUd0VHhvc09zaThKS0FBTjguIiwicm9sZXMiOlsiYWRtaW5fc2VjIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiejIxbDEtMHJNME10TlZkTmhaeFozR2E3Y3NkQlhyekRPbno1YWhWQWZMWSIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoiYWRtaW5fc2VjQGFhZHVuc3RhdHAxNC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbl9zZWNAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IlZJR3lNRmhGbUV5WC10cjNDZjQzQUEiLCJ2ZXIiOiIxLjAifQ.nayLNqinjjMCvmYK3VNZPSKoowtJAshmJrCu5dvz8-uKqjmj4Ey8fk7AvQ5FtAzOK-VcJG3Gk808frEKsm6SMp1QFOSAClv0JhBdw3KsxslPejBOHfptEp6KJH1_Xo3bktIpplW3MIUmYcGktZ9xx7Sjf6E5vsMOJFc7dBL1_DJy0m1oZoUYN8ruphFaDPE1LoLwDaqz5d2ZSjWQMaYcBWceObk5S9NJw0nRCZ9CHUAJB2Hs_-ze5ZtpIlgE5VBLR-1ExU7JH8gAnJOsoSQyAuS7qsE-Rly0gJgOxpILQgED70upSEqi2oOwsOuJ5Lr3tu7b1vyqorXPb5j_HCCn0g' \
  -H 'Content-Type: application/json' \
  -d '{
  "courseid": 5,
  "nombre": "string",
  "descripcion": "string",
  "precio": 0,
  "activo": true,
  "fecha": "2021-12-20T20:57:40.651Z"
}'


Code	Details
401 	Undocumented Error: Unauthorized


########################
#  Usuario admin_plat  #
########################

Alta de Usuario:
================

curl -X 'POST' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/admin/altaUsr/{myUser}' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDMzODI3LCJuYmYiOjE2NDAwMzM4MjcsImV4cCI6MTY0MDAzOTQ0NywiYWNyIjoiMSIsImFpbyI6IkUyWmdZQkRxWGJYK2I0bk4zYmEwODlsZWM1dWQ3WXE2aEs2dFgrTncvV21vUUhUb2xDTUEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJwbGF0YWZvcm1hIiwiZ2l2ZW5fbmFtZSI6ImFkbWluaXN0cmFkb3IiLCJpcGFkZHIiOiIxODYuMTM2LjEzOC43MSIsIm5hbWUiOiJhZG1pbl9wbGF0Iiwib2lkIjoiZTk2ZDA4OTctOTE4My00NTQ1LWFlMDktMDEyNjYzYzk1NzEzIiwicmgiOiIwLkFVWUFrXzUzZTZ6UERVQ2NrQ2NDU3VJbXlLaHhHTFpka185R3RUeG9zT3NpOEpLQUFFby4iLCJyb2xlcyI6WyJhZG1pbl9wbGF0YWZvcm1hIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiNExVVGpncXl2aF93eWt2NlZJLUQ0NmFobDE2T2kzNzZrQmluZmdWZ2lNSSIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoiYWRtaW5fcGxhdEBhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXBuIjoiYWRtaW5fcGxhdEBhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXRpIjoibHdkZlNJQ1hRRXFQRFV4a3F1eERBQSIsInZlciI6IjEuMCJ9.MN6ap_yH2WLMf_-Bq-SEn6gW8AGOtzJP-3sJLG1fJT1H057LKgwRFTHVlEoP-rZfeRVLMxf6tuYLBbSs9Bfvd1zm-kERzVFZeYjcSYW92Fm_vofWUOikVKkONqgupJpv5dGUT2EWMmc8GyQ5TqBoosDDUXoqFnYvLngmzOWwhWhUzvmxcFaMBgPk7LSCCOj_VYrCr7ibD2oGcAezfiFZzbujiuX4OcCv92FxWpDYMO9atOnVyV8n_erftg8rE0u_9qP6Iuoz6BbpyxZ-OUV8B2Tju7j1fK3RuMw-kx4uRy3IJQxSNbyfkCg-GdlQRAcKr6PcfAFMwwdaPQMgAisRaQ' \
  -H 'Content-Type: application/json' \
  -d '{
  "firstName": "William",
  "lastName": "Gates",
  "password": "qweASD123.",
  "rol": "user"
}'


Listado de Cursos:
==================

curl -X 'GET' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDMzODI3LCJuYmYiOjE2NDAwMzM4MjcsImV4cCI6MTY0MDAzOTQ0NywiYWNyIjoiMSIsImFpbyI6IkUyWmdZQkRxWGJYK2I0bk4zYmEwODlsZWM1dWQ3WXE2aEs2dFgrTncvV21vUUhUb2xDTUEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJwbGF0YWZvcm1hIiwiZ2l2ZW5fbmFtZSI6ImFkbWluaXN0cmFkb3IiLCJpcGFkZHIiOiIxODYuMTM2LjEzOC43MSIsIm5hbWUiOiJhZG1pbl9wbGF0Iiwib2lkIjoiZTk2ZDA4OTctOTE4My00NTQ1LWFlMDktMDEyNjYzYzk1NzEzIiwicmgiOiIwLkFVWUFrXzUzZTZ6UERVQ2NrQ2NDU3VJbXlLaHhHTFpka185R3RUeG9zT3NpOEpLQUFFby4iLCJyb2xlcyI6WyJhZG1pbl9wbGF0YWZvcm1hIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiNExVVGpncXl2aF93eWt2NlZJLUQ0NmFobDE2T2kzNzZrQmluZmdWZ2lNSSIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoiYWRtaW5fcGxhdEBhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXBuIjoiYWRtaW5fcGxhdEBhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXRpIjoibHdkZlNJQ1hRRXFQRFV4a3F1eERBQSIsInZlciI6IjEuMCJ9.MN6ap_yH2WLMf_-Bq-SEn6gW8AGOtzJP-3sJLG1fJT1H057LKgwRFTHVlEoP-rZfeRVLMxf6tuYLBbSs9Bfvd1zm-kERzVFZeYjcSYW92Fm_vofWUOikVKkONqgupJpv5dGUT2EWMmc8GyQ5TqBoosDDUXoqFnYvLngmzOWwhWhUzvmxcFaMBgPk7LSCCOj_VYrCr7ibD2oGcAezfiFZzbujiuX4OcCv92FxWpDYMO9atOnVyV8n_erftg8rE0u_9qP6Iuoz6BbpyxZ-OUV8B2Tju7j1fK3RuMw-kx4uRy3IJQxSNbyfkCg-GdlQRAcKr6PcfAFMwwdaPQMgAisRaQ'


Code	Details
200		Response body

[
  {
    "courseid": 1,
    "nombre": "Nombre 1",
    "descripcion": "Descripcion",
    "precio": 10,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 3,
    "nombre": "Nombre 3",
    "descripcion": "Descripcion 3",
    "precio": 30,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 4,
    "nombre": "Nombre 4",
    "descripcion": "Descripcion 4",
    "precio": 40,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 5,
    "nombre": "Nombre 5 pero a la tarde",
    "descripcion": "Diego probando 16/12 otra vez sopa ...",
    "precio": 50,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 6,
    "nombre": "Nombre 6",
    "descripcion": "Descripcion 6",
    "precio": 60,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 7,
    "nombre": "Renombrado 777",
    "descripcion": "Descripcion 777",
    "precio": 700,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 8,
    "nombre": "Nombre 666",
    "descripcion": "Descripcion 666",
    "precio": 666,
    "activo": true,
    "fecha": "2021-12-15T23:59:00"
  },
  {
    "courseid": 9,
    "nombre": "Alta Manual",
    "descripcion": "Verificano Alta despues del colapso",
    "precio": 120,
    "activo": true,
    "fecha": "2021-12-16T09:51:00"
  },
  {
    "courseid": 10,
    "nombre": "Probando mas altas",
    "descripcion": "De como como Odone te salva las papas",
    "precio": 0,
    "activo": true,
    "fecha": "2021-12-16T21:54:07"
  }
]



Datos del Curso 1:
==================
curl -X 'GET' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/1' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDMzODI3LCJuYmYiOjE2NDAwMzM4MjcsImV4cCI6MTY0MDAzOTQ0NywiYWNyIjoiMSIsImFpbyI6IkUyWmdZQkRxWGJYK2I0bk4zYmEwODlsZWM1dWQ3WXE2aEs2dFgrTncvV21vUUhUb2xDTUEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJwbGF0YWZvcm1hIiwiZ2l2ZW5fbmFtZSI6ImFkbWluaXN0cmFkb3IiLCJpcGFkZHIiOiIxODYuMTM2LjEzOC43MSIsIm5hbWUiOiJhZG1pbl9wbGF0Iiwib2lkIjoiZTk2ZDA4OTctOTE4My00NTQ1LWFlMDktMDEyNjYzYzk1NzEzIiwicmgiOiIwLkFVWUFrXzUzZTZ6UERVQ2NrQ2NDU3VJbXlLaHhHTFpka185R3RUeG9zT3NpOEpLQUFFby4iLCJyb2xlcyI6WyJhZG1pbl9wbGF0YWZvcm1hIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiNExVVGpncXl2aF93eWt2NlZJLUQ0NmFobDE2T2kzNzZrQmluZmdWZ2lNSSIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoiYWRtaW5fcGxhdEBhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXBuIjoiYWRtaW5fcGxhdEBhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXRpIjoibHdkZlNJQ1hRRXFQRFV4a3F1eERBQSIsInZlciI6IjEuMCJ9.MN6ap_yH2WLMf_-Bq-SEn6gW8AGOtzJP-3sJLG1fJT1H057LKgwRFTHVlEoP-rZfeRVLMxf6tuYLBbSs9Bfvd1zm-kERzVFZeYjcSYW92Fm_vofWUOikVKkONqgupJpv5dGUT2EWMmc8GyQ5TqBoosDDUXoqFnYvLngmzOWwhWhUzvmxcFaMBgPk7LSCCOj_VYrCr7ibD2oGcAezfiFZzbujiuX4OcCv92FxWpDYMO9atOnVyV8n_erftg8rE0u_9qP6Iuoz6BbpyxZ-OUV8B2Tju7j1fK3RuMw-kx4uRy3IJQxSNbyfkCg-GdlQRAcKr6PcfAFMwwdaPQMgAisRaQ'


Code	Details
200		Response body

{
  "courseid": 1,
  "nombre": "Nombre 1",
  "descripcion": "Descripcion",
  "precio": 10,
  "activo": true,
  "fecha": "2021-12-15T17:57:00"
}


Borrar curso 5:
===============
curl -X 'DELETE' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/5' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDQyNjUyLCJuYmYiOjE2NDAwNDI2NTIsImV4cCI6MTY0MDA0NzQ1NSwiYWNyIjoiMSIsImFpbyI6IkFTUUEyLzhUQUFBQWJNbTN1TCtKKzI2WWtUcjZ3bGszdkZtVldtcmFRSFdzVW1aRDJsVWU4UVk9IiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6ImI2MTg3MWE4LTkzNWQtNDZmZi1iNTNjLTY4YjBlYjIyZjA5MiIsImFwcGlkYWNyIjoiMSIsImZhbWlseV9uYW1lIjoicGxhdGFmb3JtYSIsImdpdmVuX25hbWUiOiJhZG1pbmlzdHJhZG9yIiwiaXBhZGRyIjoiMTg2LjEzNi4xMzguNzEiLCJuYW1lIjoiYWRtaW5fcGxhdCIsIm9pZCI6ImU5NmQwODk3LTkxODMtNDU0NS1hZTA5LTAxMjY2M2M5NTcxMyIsInJoIjoiMC5BVVlBa181M2U2elBEVUNja0NjQ1N1SW15S2h4R0xaZGtfOUd0VHhvc09zaThKS0FBRW8uIiwicm9sZXMiOlsiYWRtaW5fcGxhdCJdLCJzY3AiOiJBcHBsaWNhdGlvbi5SZWFkV3JpdGUuQWxsIEFwcFJvbGVBc3NpZ25tZW50LlJlYWRXcml0ZS5BbGwgRGlyZWN0b3J5LlJlYWRXcml0ZS5BbGwgVXNlci5SZWFkIFVzZXIuUmVhZFdyaXRlLkFsbCBhY2Nlc3NfYXNfdXNlciIsInN1YiI6IjRMVVRqZ3F5dmhfd3lrdjZWSS1ENDZhaGwxNk9pMzc2a0JpbmZnVmdpTUkiLCJ0aWQiOiI3Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgiLCJ1bmlxdWVfbmFtZSI6ImFkbWluX3BsYXRAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInVwbiI6ImFkbWluX3BsYXRAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IlVMM2lNUmlLd1UtSVVHZk1hbThzQUEiLCJ2ZXIiOiIxLjAifQ.rhno9w09QkOAVW5TmOWtbSuNYlcMVWJaQrY-ebLDVEQS8BTeC1dFS5T0E4KC5hWDMPwBUSRoeZhEobXYuvM9FXCOOTOZjZz32K7Tq5SbppoTfFtC4YeYfQ2nCxIJRtZpnP7qeiCai8Mwjmr20XIeUifl1IhhFf9cSJSg1-3h_StfIhO1cEHXsW2MiD95XcECF5YNawEkF_K8I0J5rkGau96TZgPgE0hK86mtrcst5s9gPii9K14Dm_BiBZYQAkXubzIa6Z6PhHBhHdayWRtJrWz83zoXjDK4bMKqo_w5nHL7AXdaCaRQ1UFZN_rgbXzKnYvtnuMK6p1eZaaN-jVZ-w'

Code	Details
200		Response headers


Agregar de curso:
=================

curl -X 'POST' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/{course}' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDQyNjUyLCJuYmYiOjE2NDAwNDI2NTIsImV4cCI6MTY0MDA0NzQ1NSwiYWNyIjoiMSIsImFpbyI6IkFTUUEyLzhUQUFBQWJNbTN1TCtKKzI2WWtUcjZ3bGszdkZtVldtcmFRSFdzVW1aRDJsVWU4UVk9IiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6ImI2MTg3MWE4LTkzNWQtNDZmZi1iNTNjLTY4YjBlYjIyZjA5MiIsImFwcGlkYWNyIjoiMSIsImZhbWlseV9uYW1lIjoicGxhdGFmb3JtYSIsImdpdmVuX25hbWUiOiJhZG1pbmlzdHJhZG9yIiwiaXBhZGRyIjoiMTg2LjEzNi4xMzguNzEiLCJuYW1lIjoiYWRtaW5fcGxhdCIsIm9pZCI6ImU5NmQwODk3LTkxODMtNDU0NS1hZTA5LTAxMjY2M2M5NTcxMyIsInJoIjoiMC5BVVlBa181M2U2elBEVUNja0NjQ1N1SW15S2h4R0xaZGtfOUd0VHhvc09zaThKS0FBRW8uIiwicm9sZXMiOlsiYWRtaW5fcGxhdCJdLCJzY3AiOiJBcHBsaWNhdGlvbi5SZWFkV3JpdGUuQWxsIEFwcFJvbGVBc3NpZ25tZW50LlJlYWRXcml0ZS5BbGwgRGlyZWN0b3J5LlJlYWRXcml0ZS5BbGwgVXNlci5SZWFkIFVzZXIuUmVhZFdyaXRlLkFsbCBhY2Nlc3NfYXNfdXNlciIsInN1YiI6IjRMVVRqZ3F5dmhfd3lrdjZWSS1ENDZhaGwxNk9pMzc2a0JpbmZnVmdpTUkiLCJ0aWQiOiI3Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgiLCJ1bmlxdWVfbmFtZSI6ImFkbWluX3BsYXRAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInVwbiI6ImFkbWluX3BsYXRAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IlVMM2lNUmlLd1UtSVVHZk1hbThzQUEiLCJ2ZXIiOiIxLjAifQ.rhno9w09QkOAVW5TmOWtbSuNYlcMVWJaQrY-ebLDVEQS8BTeC1dFS5T0E4KC5hWDMPwBUSRoeZhEobXYuvM9FXCOOTOZjZz32K7Tq5SbppoTfFtC4YeYfQ2nCxIJRtZpnP7qeiCai8Mwjmr20XIeUifl1IhhFf9cSJSg1-3h_StfIhO1cEHXsW2MiD95XcECF5YNawEkF_K8I0J5rkGau96TZgPgE0hK86mtrcst5s9gPii9K14Dm_BiBZYQAkXubzIa6Z6PhHBhHdayWRtJrWz83zoXjDK4bMKqo_w5nHL7AXdaCaRQ1UFZN_rgbXzKnYvtnuMK6p1eZaaN-jVZ-w' \
  -H 'Content-Type: application/json' \
  -d '{
  "courseid": 0,
  "nombre": "Apis Seguros",
  "descripcion": "Aseguramiento de APIS avanzado",
  "precio": 112,
  "activo": true,
  "fecha": "2022-02-01T21:15:09.291Z"
}'


Code	Details
201		Undocumented Response headers


Modificar curso 11:
==================
curl -X 'PUT' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/{course}' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDQyNjUyLCJuYmYiOjE2NDAwNDI2NTIsImV4cCI6MTY0MDA0NzQ1NSwiYWNyIjoiMSIsImFpbyI6IkFTUUEyLzhUQUFBQWJNbTN1TCtKKzI2WWtUcjZ3bGszdkZtVldtcmFRSFdzVW1aRDJsVWU4UVk9IiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6ImI2MTg3MWE4LTkzNWQtNDZmZi1iNTNjLTY4YjBlYjIyZjA5MiIsImFwcGlkYWNyIjoiMSIsImZhbWlseV9uYW1lIjoicGxhdGFmb3JtYSIsImdpdmVuX25hbWUiOiJhZG1pbmlzdHJhZG9yIiwiaXBhZGRyIjoiMTg2LjEzNi4xMzguNzEiLCJuYW1lIjoiYWRtaW5fcGxhdCIsIm9pZCI6ImU5NmQwODk3LTkxODMtNDU0NS1hZTA5LTAxMjY2M2M5NTcxMyIsInJoIjoiMC5BVVlBa181M2U2elBEVUNja0NjQ1N1SW15S2h4R0xaZGtfOUd0VHhvc09zaThKS0FBRW8uIiwicm9sZXMiOlsiYWRtaW5fcGxhdCJdLCJzY3AiOiJBcHBsaWNhdGlvbi5SZWFkV3JpdGUuQWxsIEFwcFJvbGVBc3NpZ25tZW50LlJlYWRXcml0ZS5BbGwgRGlyZWN0b3J5LlJlYWRXcml0ZS5BbGwgVXNlci5SZWFkIFVzZXIuUmVhZFdyaXRlLkFsbCBhY2Nlc3NfYXNfdXNlciIsInN1YiI6IjRMVVRqZ3F5dmhfd3lrdjZWSS1ENDZhaGwxNk9pMzc2a0JpbmZnVmdpTUkiLCJ0aWQiOiI3Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgiLCJ1bmlxdWVfbmFtZSI6ImFkbWluX3BsYXRAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInVwbiI6ImFkbWluX3BsYXRAYWFkdW5zdGF0cDE0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IlVMM2lNUmlLd1UtSVVHZk1hbThzQUEiLCJ2ZXIiOiIxLjAifQ.rhno9w09QkOAVW5TmOWtbSuNYlcMVWJaQrY-ebLDVEQS8BTeC1dFS5T0E4KC5hWDMPwBUSRoeZhEobXYuvM9FXCOOTOZjZz32K7Tq5SbppoTfFtC4YeYfQ2nCxIJRtZpnP7qeiCai8Mwjmr20XIeUifl1IhhFf9cSJSg1-3h_StfIhO1cEHXsW2MiD95XcECF5YNawEkF_K8I0J5rkGau96TZgPgE0hK86mtrcst5s9gPii9K14Dm_BiBZYQAkXubzIa6Z6PhHBhHdayWRtJrWz83zoXjDK4bMKqo_w5nHL7AXdaCaRQ1UFZN_rgbXzKnYvtnuMK6p1eZaaN-jVZ-w' \
  -H 'Content-Type: application/json' \
  -d '  {
    "courseid": 11,
    "nombre": "Apis Seguros",
    "descripcion": "Aseguramiento de APIS avanzado",
    "precio": 120,
    "activo": true,
    "fecha": "2022-02-01T21:15:09"
  }'

Code	Details
202	Undocumented




########################
#  Usuario usuario     #
########################

Alta de Usuario:
================
curl -X 'POST' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/admin/altaUsr/{myUser}' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDQzMjAzLCJuYmYiOjE2NDAwNDMyMDMsImV4cCI6MTY0MDA0Nzg0MiwiYWNyIjoiMSIsImFpbyI6IkUyWmdZUGovS2JMN1VGbmlvMnV4WGNmMjhrZzFzRXhjcXNhL1lXdlBmeE9tYXRaTm1SOEEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJ1c3VhcmlvIiwiZ2l2ZW5fbmFtZSI6InVzdWFyaW8iLCJpcGFkZHIiOiIxODYuMTM2LjEzOC43MSIsIm5hbWUiOiJ1c3VhcmlvIiwib2lkIjoiYzE2Y2M5ZWItZTdmMC00NGZhLThhNmEtZDM0MzcxYTI3MjNkIiwicmgiOiIwLkFVWUFrXzUzZTZ6UERVQ2NrQ2NDU3VJbXlLaHhHTFpka185R3RUeG9zT3NpOEpLQUFDWS4iLCJyb2xlcyI6WyJ1c2VyIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiTUVaQl8waEF4WGZKc3dtRC1ScUlIbElqVVZ1My1Vb1dnQk9Xd0R0MndVZyIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXBuIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXRpIjoiRWJuSWxSN1M1a1NnR2lyakI0Zy1BQSIsInZlciI6IjEuMCJ9.kwsBu5LGqdVfHDxjeuG4rllIoAgXu7nMS5fYDjflmhW8QpKAT_d8HLaUdEQ6G1bUPQogVh8KlEQKAEUzmnhvIPIwh0rnvpJHB8Z1nOrjDLT1eX3gj_y4-LSv_Oi2gWZKq9wgl63Lz1yYUtMKI3SQTSAtxysZsRawEI9ofTOpA1prejlpnItRgbfpCtnBTchCH4LXXf_DLbax2vyxxDUdqD0w0orO9u9UfM4SbKDyZ0OPkbb0t2Yl7Q8O_Js8EobKVfZWzwoNfDguE22Z0vl34SWcdhdBZrcuiMnDrZxmtoaE7Z2TpnkSY8sIhx26acoVytvn9c9ee6mBJTRVsT28uQ' \
  -H 'Content-Type: application/json' \
  -d '{
  "firstName": "William",
  "lastName": "Gates",
  "password": "qweASD123.",
  "rol": "user"
}'

Code	Details
401		Undocumented	Error: Unauthorized



Listado de Cursos:
==================
curl -X 'GET' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDQzMjAzLCJuYmYiOjE2NDAwNDMyMDMsImV4cCI6MTY0MDA0Nzg0MiwiYWNyIjoiMSIsImFpbyI6IkUyWmdZUGovS2JMN1VGbmlvMnV4WGNmMjhrZzFzRXhjcXNhL1lXdlBmeE9tYXRaTm1SOEEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJ1c3VhcmlvIiwiZ2l2ZW5fbmFtZSI6InVzdWFyaW8iLCJpcGFkZHIiOiIxODYuMTM2LjEzOC43MSIsIm5hbWUiOiJ1c3VhcmlvIiwib2lkIjoiYzE2Y2M5ZWItZTdmMC00NGZhLThhNmEtZDM0MzcxYTI3MjNkIiwicmgiOiIwLkFVWUFrXzUzZTZ6UERVQ2NrQ2NDU3VJbXlLaHhHTFpka185R3RUeG9zT3NpOEpLQUFDWS4iLCJyb2xlcyI6WyJ1c2VyIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiTUVaQl8waEF4WGZKc3dtRC1ScUlIbElqVVZ1My1Vb1dnQk9Xd0R0MndVZyIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXBuIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXRpIjoiRWJuSWxSN1M1a1NnR2lyakI0Zy1BQSIsInZlciI6IjEuMCJ9.kwsBu5LGqdVfHDxjeuG4rllIoAgXu7nMS5fYDjflmhW8QpKAT_d8HLaUdEQ6G1bUPQogVh8KlEQKAEUzmnhvIPIwh0rnvpJHB8Z1nOrjDLT1eX3gj_y4-LSv_Oi2gWZKq9wgl63Lz1yYUtMKI3SQTSAtxysZsRawEI9ofTOpA1prejlpnItRgbfpCtnBTchCH4LXXf_DLbax2vyxxDUdqD0w0orO9u9UfM4SbKDyZ0OPkbb0t2Yl7Q8O_Js8EobKVfZWzwoNfDguE22Z0vl34SWcdhdBZrcuiMnDrZxmtoaE7Z2TpnkSY8sIhx26acoVytvn9c9ee6mBJTRVsT28uQ'

Code	Details
200		Response body

[
  {
    "courseid": 1,
    "nombre": "Nombre 1",
    "descripcion": "Descripcion",
    "precio": 10,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 3,
    "nombre": "Nombre 3",
    "descripcion": "Descripcion 3",
    "precio": 30,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 4,
    "nombre": "Nombre 4",
    "descripcion": "Descripcion 4",
    "precio": 40,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 6,
    "nombre": "Nombre 6",
    "descripcion": "Descripcion 6",
    "precio": 60,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 7,
    "nombre": "Renombrado 777",
    "descripcion": "Descripcion 777",
    "precio": 700,
    "activo": true,
    "fecha": "2021-12-15T17:57:00"
  },
  {
    "courseid": 8,
    "nombre": "Nombre 666",
    "descripcion": "Descripcion 666",
    "precio": 666,
    "activo": true,
    "fecha": "2021-12-15T23:59:00"
  },
  {
    "courseid": 9,
    "nombre": "Alta Manual",
    "descripcion": "Verificano Alta despues del colapso",
    "precio": 120,
    "activo": true,
    "fecha": "2021-12-16T09:51:00"
  },
  {
    "courseid": 10,
    "nombre": "Probando mas altas",
    "descripcion": "De como como Odone te salva las papas",
    "precio": 0,
    "activo": true,
    "fecha": "2021-12-16T21:54:07"
  },
  {
    "courseid": 11,
    "nombre": "Apis Seguros",
    "descripcion": "Aseguramiento de APIS avanzado",
    "precio": 120,
    "activo": true,
    "fecha": "2022-02-01T21:15:09"
  }
]


Datos del Curso 1:
==================
curl -X 'GET' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/1' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDQzMjAzLCJuYmYiOjE2NDAwNDMyMDMsImV4cCI6MTY0MDA0Nzg0MiwiYWNyIjoiMSIsImFpbyI6IkUyWmdZUGovS2JMN1VGbmlvMnV4WGNmMjhrZzFzRXhjcXNhL1lXdlBmeE9tYXRaTm1SOEEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJ1c3VhcmlvIiwiZ2l2ZW5fbmFtZSI6InVzdWFyaW8iLCJpcGFkZHIiOiIxODYuMTM2LjEzOC43MSIsIm5hbWUiOiJ1c3VhcmlvIiwib2lkIjoiYzE2Y2M5ZWItZTdmMC00NGZhLThhNmEtZDM0MzcxYTI3MjNkIiwicmgiOiIwLkFVWUFrXzUzZTZ6UERVQ2NrQ2NDU3VJbXlLaHhHTFpka185R3RUeG9zT3NpOEpLQUFDWS4iLCJyb2xlcyI6WyJ1c2VyIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiTUVaQl8waEF4WGZKc3dtRC1ScUlIbElqVVZ1My1Vb1dnQk9Xd0R0MndVZyIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXBuIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXRpIjoiRWJuSWxSN1M1a1NnR2lyakI0Zy1BQSIsInZlciI6IjEuMCJ9.kwsBu5LGqdVfHDxjeuG4rllIoAgXu7nMS5fYDjflmhW8QpKAT_d8HLaUdEQ6G1bUPQogVh8KlEQKAEUzmnhvIPIwh0rnvpJHB8Z1nOrjDLT1eX3gj_y4-LSv_Oi2gWZKq9wgl63Lz1yYUtMKI3SQTSAtxysZsRawEI9ofTOpA1prejlpnItRgbfpCtnBTchCH4LXXf_DLbax2vyxxDUdqD0w0orO9u9UfM4SbKDyZ0OPkbb0t2Yl7Q8O_Js8EobKVfZWzwoNfDguE22Z0vl34SWcdhdBZrcuiMnDrZxmtoaE7Z2TpnkSY8sIhx26acoVytvn9c9ee6mBJTRVsT28uQ'

Code	Details
200		Response body

{
  "courseid": 1,
  "nombre": "Nombre 1",
  "descripcion": "Descripcion",
  "precio": 10,
  "activo": true,
  "fecha": "2021-12-15T17:57:00"
}

Borrar curso 5:
===============
curl -X 'DELETE' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/5' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDQzMjAzLCJuYmYiOjE2NDAwNDMyMDMsImV4cCI6MTY0MDA0Nzg0MiwiYWNyIjoiMSIsImFpbyI6IkUyWmdZUGovS2JMN1VGbmlvMnV4WGNmMjhrZzFzRXhjcXNhL1lXdlBmeE9tYXRaTm1SOEEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJ1c3VhcmlvIiwiZ2l2ZW5fbmFtZSI6InVzdWFyaW8iLCJpcGFkZHIiOiIxODYuMTM2LjEzOC43MSIsIm5hbWUiOiJ1c3VhcmlvIiwib2lkIjoiYzE2Y2M5ZWItZTdmMC00NGZhLThhNmEtZDM0MzcxYTI3MjNkIiwicmgiOiIwLkFVWUFrXzUzZTZ6UERVQ2NrQ2NDU3VJbXlLaHhHTFpka185R3RUeG9zT3NpOEpLQUFDWS4iLCJyb2xlcyI6WyJ1c2VyIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiTUVaQl8waEF4WGZKc3dtRC1ScUlIbElqVVZ1My1Vb1dnQk9Xd0R0MndVZyIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXBuIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXRpIjoiRWJuSWxSN1M1a1NnR2lyakI0Zy1BQSIsInZlciI6IjEuMCJ9.kwsBu5LGqdVfHDxjeuG4rllIoAgXu7nMS5fYDjflmhW8QpKAT_d8HLaUdEQ6G1bUPQogVh8KlEQKAEUzmnhvIPIwh0rnvpJHB8Z1nOrjDLT1eX3gj_y4-LSv_Oi2gWZKq9wgl63Lz1yYUtMKI3SQTSAtxysZsRawEI9ofTOpA1prejlpnItRgbfpCtnBTchCH4LXXf_DLbax2vyxxDUdqD0w0orO9u9UfM4SbKDyZ0OPkbb0t2Yl7Q8O_Js8EobKVfZWzwoNfDguE22Z0vl34SWcdhdBZrcuiMnDrZxmtoaE7Z2TpnkSY8sIhx26acoVytvn9c9ee6mBJTRVsT28uQ'

Code	Details
401		Undocumented	Error: Unauthorized



Agregar de curso:
=================
curl -X 'POST' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/{course}' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDQzMjAzLCJuYmYiOjE2NDAwNDMyMDMsImV4cCI6MTY0MDA0Nzg0MiwiYWNyIjoiMSIsImFpbyI6IkUyWmdZUGovS2JMN1VGbmlvMnV4WGNmMjhrZzFzRXhjcXNhL1lXdlBmeE9tYXRaTm1SOEEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJ1c3VhcmlvIiwiZ2l2ZW5fbmFtZSI6InVzdWFyaW8iLCJpcGFkZHIiOiIxODYuMTM2LjEzOC43MSIsIm5hbWUiOiJ1c3VhcmlvIiwib2lkIjoiYzE2Y2M5ZWItZTdmMC00NGZhLThhNmEtZDM0MzcxYTI3MjNkIiwicmgiOiIwLkFVWUFrXzUzZTZ6UERVQ2NrQ2NDU3VJbXlLaHhHTFpka185R3RUeG9zT3NpOEpLQUFDWS4iLCJyb2xlcyI6WyJ1c2VyIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiTUVaQl8waEF4WGZKc3dtRC1ScUlIbElqVVZ1My1Vb1dnQk9Xd0R0MndVZyIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXBuIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXRpIjoiRWJuSWxSN1M1a1NnR2lyakI0Zy1BQSIsInZlciI6IjEuMCJ9.kwsBu5LGqdVfHDxjeuG4rllIoAgXu7nMS5fYDjflmhW8QpKAT_d8HLaUdEQ6G1bUPQogVh8KlEQKAEUzmnhvIPIwh0rnvpJHB8Z1nOrjDLT1eX3gj_y4-LSv_Oi2gWZKq9wgl63Lz1yYUtMKI3SQTSAtxysZsRawEI9ofTOpA1prejlpnItRgbfpCtnBTchCH4LXXf_DLbax2vyxxDUdqD0w0orO9u9UfM4SbKDyZ0OPkbb0t2Yl7Q8O_Js8EobKVfZWzwoNfDguE22Z0vl34SWcdhdBZrcuiMnDrZxmtoaE7Z2TpnkSY8sIhx26acoVytvn9c9ee6mBJTRVsT28uQ' \
  -H 'Content-Type: application/json' \
  -d '{
  "courseid": 0,
  "nombre": "Esperando Fallo",
  "descripcion": "Como esperar que falle el alta",
  "precio": 666,
  "activo": true,
  "fecha": "2021-12-20T20:55:54.266Z"
}'


Code	Details
401		Undocumented Error: Unauthorized


Modificar curso 5:
==================
curl -X 'PUT' \
  'https://unstatpfinalgrupo14.azurewebsites.net/api/course/{course}' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCIsImtpZCI6Ik1yNS1BVWliZkJpaTdOZDFqQmViYXhib1hXMCJ9.eyJhdWQiOiJhcGk6Ly9iNjE4NzFhOC05MzVkLTQ2ZmYtYjUzYy02OGIwZWIyMmYwOTIiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83Yjc3ZmU5My1jZmFjLTQwMGQtOWM5MC0yNzAyNGFlMjI2YzgvIiwiaWF0IjoxNjQwMDQzMjAzLCJuYmYiOjE2NDAwNDMyMDMsImV4cCI6MTY0MDA0Nzg0MiwiYWNyIjoiMSIsImFpbyI6IkUyWmdZUGovS2JMN1VGbmlvMnV4WGNmMjhrZzFzRXhjcXNhL1lXdlBmeE9tYXRaTm1SOEEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiYjYxODcxYTgtOTM1ZC00NmZmLWI1M2MtNjhiMGViMjJmMDkyIiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJ1c3VhcmlvIiwiZ2l2ZW5fbmFtZSI6InVzdWFyaW8iLCJpcGFkZHIiOiIxODYuMTM2LjEzOC43MSIsIm5hbWUiOiJ1c3VhcmlvIiwib2lkIjoiYzE2Y2M5ZWItZTdmMC00NGZhLThhNmEtZDM0MzcxYTI3MjNkIiwicmgiOiIwLkFVWUFrXzUzZTZ6UERVQ2NrQ2NDU3VJbXlLaHhHTFpka185R3RUeG9zT3NpOEpLQUFDWS4iLCJyb2xlcyI6WyJ1c2VyIl0sInNjcCI6IkFwcGxpY2F0aW9uLlJlYWRXcml0ZS5BbGwgQXBwUm9sZUFzc2lnbm1lbnQuUmVhZFdyaXRlLkFsbCBEaXJlY3RvcnkuUmVhZFdyaXRlLkFsbCBVc2VyLlJlYWQgVXNlci5SZWFkV3JpdGUuQWxsIGFjY2Vzc19hc191c2VyIiwic3ViIjoiTUVaQl8waEF4WGZKc3dtRC1ScUlIbElqVVZ1My1Vb1dnQk9Xd0R0MndVZyIsInRpZCI6IjdiNzdmZTkzLWNmYWMtNDAwZC05YzkwLTI3MDI0YWUyMjZjOCIsInVuaXF1ZV9uYW1lIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXBuIjoidXN1YXJpb0BhYWR1bnN0YXRwMTQub25taWNyb3NvZnQuY29tIiwidXRpIjoiRWJuSWxSN1M1a1NnR2lyakI0Zy1BQSIsInZlciI6IjEuMCJ9.kwsBu5LGqdVfHDxjeuG4rllIoAgXu7nMS5fYDjflmhW8QpKAT_d8HLaUdEQ6G1bUPQogVh8KlEQKAEUzmnhvIPIwh0rnvpJHB8Z1nOrjDLT1eX3gj_y4-LSv_Oi2gWZKq9wgl63Lz1yYUtMKI3SQTSAtxysZsRawEI9ofTOpA1prejlpnItRgbfpCtnBTchCH4LXXf_DLbax2vyxxDUdqD0w0orO9u9UfM4SbKDyZ0OPkbb0t2Yl7Q8O_Js8EobKVfZWzwoNfDguE22Z0vl34SWcdhdBZrcuiMnDrZxmtoaE7Z2TpnkSY8sIhx26acoVytvn9c9ee6mBJTRVsT28uQ' \
  -H 'Content-Type: application/json' \
  -d '{
  "courseid": 5,
  "nombre": "Nuevo Nombre",
  "descripcion": "Intento de cambio de nombre",
  "precio": 120,
  "activo": true,
  "fecha": "2021-12-20T20:57:40.651Z"
}'


Code	Details
401		Undocumented Error: Unauthorized