import re
import fitz
import os
import shutil
#!/usr/bin/python
# -*- coding: UTF-8 -*-
import sys
sys.path.append("C:\Program Files")
sys.path.append("C:\Program Files\IronPython 2.7")
sys.path.append("C:\Program Files\IronPython 2.7\Lib")



Listar = (r"Senasoft\PermissionManagement.MVC\Uploads\Factura")
archivos = os.listdir(Listar)

#pdf_documento="archivos"
Facturas = (r"Uploads\FacturaElectronica")
notaCredito =(r"Uploads\Nota_credito")
notaDebito = (r"Uploads\Nota_Debito")
desconocido = (r"Uploads\Desconocido")
cuentasCobro = (r"Uploads\CuentasCobro")



for xd in archivos: 
    if ".pdf" in xd:
        documento = fitz.open(xd)
        pagina = documento.load_page(0)
        text=pagina.get_text("text")
    

        buscar=re.findall(r'Factura Electrónica de Venta', text)
        #NotaC=re.findall(r'Factura', text)
        documento = ""
        #print(buscar)
        if len(re.findall(r'Factura Electrónica de Venta', text)) > 0 or len(re.findall(r'Factura Electrónica de venta', text)) > 0 or len(re.findall(r'FACTURA ELECTRONICA DE VENTA', text)) > 0 or len(re.findall(r'FACTURA ELECTRÓNICA DE VENTA', text)) > 0 : 
            new_route = shutil.move(f"{Listar}/{xd}",Facturas)
            text = "" 
            documento = ""
        elif len(re.findall(r'Nota crédito', text)) > 0 : 
            new_route = shutil.move(f"{Listar}/{xd}",notaCredito)
            text = "" 
            documento = ""
        elif len(re.findall(r'Nota débito', text)) > 0 : 
            new_route = shutil.move(f"{Listar}/{xd}",notaDebito)
            text = "" 
            documento = ""
        elif len(re.findall(r'Cuentas de cobro', text)) > 0 : 
            new_route = shutil.move(f"{Listar}/{xd}",cuentasCobro)
            text = "" 
            documento = ""
        else:
            new_route = shutil.move(f"{Listar}/{xd}",desconocido)
            text = "" 
            documento = ""



        
            





        
            



