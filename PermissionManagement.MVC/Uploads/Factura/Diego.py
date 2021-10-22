#!/usr/bin/python
# -*- coding: UTF-8 -*-
import re
import fitz
import os
import shutil


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
        documento = fitz.open(xd)
        pagina = documento.load_page(0)
        text=pagina.get_text("text")
    

        buscar=re.findall(r'Factura Electrónica de Venta', text)
        #NotaC=re.findall(r'Factura', text)
        documento = ""
        data = r"{}/{}".format(Listar,xd)
        #print(buscar)
        if len(re.findall(r'Factura Electrónica de Venta', text)) > 0 or len(re.findall(r'Factura Electrónica de venta', text)) > 0 or len(re.findall(r'FACTURA ELECTRONICA DE VENTA', text)) > 0 or len(re.findall(r'FACTURA ELECTRÓNICA DE VENTA', text)) > 0 : 
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
            new_route = shutil.move(data,desconocido)
            text = "" 
            documento = ""



        
            





        
            



