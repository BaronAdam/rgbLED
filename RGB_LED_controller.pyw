import serial
from tkinter import *
from tkinter.colorchooser import *
import time
import struct

root = Tk()

ser = serial.Serial('com3', 9600)


def get_color():
    eColor.delete(0, END)
    color_ = str(askcolor())
    a = color_.split('#')
    a1 = a[1].split("'")
    eColor.insert(0, a1[0])
    color()


def rainbow():
    ser.write(b'r')


def red():
    ser.write(b'R')


def green():
    ser.write(b'G')


def blue():
    ser.write(b'B')


def plus():
    ser.write(b'+')


def minus():
    ser.write(b'-')


def rainbow2():
    ser.write(b't')


def white():
    ser.write(b'W')


def zero():
    ser.write(b'z')


def half():
    ser.write(b'h')


def max_():
    ser.write(b'f')


def color():
    line = eColor.get()
    o = []
    while line:
        o.append(line[:2])
        line = line[2:]

    o[0] = int(o[0], 16)
    o[1] = int(o[1], 16)
    o[2] = int(o[2], 16)
    ser.write(b'C')
    ser.write(struct.pack('>B', o[0]))
    ser.write(struct.pack('>B', o[1]))
    ser.write(struct.pack('>B', o[2]))


def plus_speed():
    ser.write(b']')


def minus_speed():
    ser.write(b'[')


def reset_speed():
    ser.write(b'[')


def set_brightness():
    slider_value = int(sBrightness.get())
    ser.write(b'b')
    ser.write(struct.pack('>B', slider_value))


time.sleep(2)

bRainbow = Button(root, text="Rainbow", command=rainbow, width="25")
bRainbow2 = Button(root, text="Rainbow 2", command=rainbow2, width="25")
bRed = Button(root, text="Red", command=red, width="25")
bGreen = Button(root, text="Green", command=green, width="25")
bBlue = Button(root, text="Blue", command=blue, width="25")
bWhite = Button(root, text="White", command=white, width="25")
sBrightness = Scale(root, from_=0, to=100, orient=HORIZONTAL, resolution=5)
sBrightness.set(50)
bBrightness = Button(root, text="Set Brightness", command=set_brightness, width="25")
bPlusSpeed = Button(root, text="Speed +", command=plus_speed, width="25")
bMinusSpeed = Button(root, text="Speed -", command=minus_speed, width="25")
bResetSpeed = Button(root, text="Reset Speed", command=reset_speed, width="25")
eColor = Entry(root, width="25")
bGetColor = Button(root, text="Choose Color", command=get_color, width="25")
bColor = Button(root, text="Change Color", command=color, width="25")

bRainbow.pack()
bRainbow2.pack()
bRed.pack()
bGreen.pack()
bBlue.pack()
bWhite.pack()
sBrightness.pack()
bBrightness.pack()
bPlusSpeed.pack()
bMinusSpeed.pack()
bResetSpeed.pack()
eColor.pack()
bGetColor.pack()
bColor.pack()
root.mainloop()

ser.close()
