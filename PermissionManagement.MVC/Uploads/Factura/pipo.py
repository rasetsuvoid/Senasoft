#!/usr/bin/python
# -*- coding: UTF-8 -*-
import sys
sys.path.append("C:\Program Files")
sys.path.append("C:\Program Files\IronPython 2.7")
sys.path.append("C:\Program Files\IronPython 2.7\Lib")
import os
import shutil

source = (r"C:\Users\SENA\Documents\PDF_purebas")

destination =(r"C:\Users\SENA\Documents\RutaII")



archivos = os.listdir(source)

for pdf_p in archivos:
   
   if ".pdf" in pdf_p:
      data = r"{}/{}".format(source,pdf_p)
      shutil.move(data, destination)


        




