from get import Voll
import os

record = Voll()

test = record.getWord()
file = open("work.pls","w")
file.write(str(record))
file.close()
