#!/usr/bin/python
# -*- coding: UTF-8 -*-
import re
import sys
sys.path.append("C:\Program Files\IronPython 2.7")
sys.path.append("C:\Program Files\IronPython 2.7\Lib")
sys.path.append("C:\Program Files\IronPython 2.7\Lib\site-packages")

import os
import shutil
import re
import PyPDF2

Listar = (r"C:\Users\SENA\Documents\GitHub\Senasoft\PermissionManagement.MVC\Uploads\Factura")
archivos = os.listdir(Listar)

#pdf_documento="archivos"
Facturas = (r"C:\Users\SENA\Documents\GitHub\Senasoft\PermissionManagement.MVC\Uploads\FacturaElectronica")
notaCredito =(r"C:\Users\SENA\Documents\GitHub\Senasoft\PermissionManagement.MVC\Uploads\Nota_credito")
notaDebito = (r"C:\Users\SENA\Documents\GitHub\Senasoft\PermissionManagement.MVC\Uploads\Nota_Debito")
desconocido = (r"C:\Users\SENA\Documents\GitHub\Senasoft\PermissionManagement.MVC\Uploads\Desconocido")
cuentasCobro = (r"C:\Users\SENA\Documents\GitHub\Senasoft\PermissionManagement.MVC\Uploads\CuentasCobro")



for xd in archivos: 
    if ".pdf" in xd:
        data = r"{}/{}".format(Listar,xd)
        documento = open(data)
        documento = PyPDF2.PdfFileReader(data)
        pagina = documento.getPage(0)
        text=(pagina.extractText())
    

        #buscar=re.findall(r'Factura Electrónica de Venta', text)
        #NotaC=re.findall(r'Factura', text)
        #documento = ""
        #data = r"{}/{}".format(Listar,xd)
        #print(buscar)
        if len(re.findall(r'Factura Electrónica de Venta', text)) > 0 or len(re.findall(r'Factura Electrónica de venta', text)) > 0 or len(re.findall(r'FACTURA ELECTRONICA DE VENTA', text)) > 0 or len(re.findall(r'FACTURA ELECTRÓNICA DE VENTA', text)) > 0 or len(re.findall(r'Factura Electronica de Venta', text)) > 0: 
            if os.path.exists(r"{}/{}".format(Facturas,xd)):
                pass
            else:
                new_route = shutil.move(data,Facturas)
                text = "" 
                documento = ""
        elif len(re.findall(r'Nota crédito', text)) > 0 : 
            new_route = shutil.move(data,notaCredito)
            text = "" 
            documento = ""
        elif len(re.findall(r'Nota débito', text)) > 0 : 
            new_route = shutil.move(data,notaDebito)
            text = "" 
            documento = ""
        elif len(re.findall(r'Cuentas de cobro', text)) > 0 : 
            new_route = shutil.move(data,cuentasCobro)
            text = "" 
            documento = ""
        else:
            if os.path.exists(r"{}/{}".format(Facturas,xd)):
                pass
            else: 
                new_route = shutil.move(data,Listar)
                text = "" 
                documento = ""



        
            





        
            



