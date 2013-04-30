#!/usr/bin/python
# This program is free software; you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation; either version 2 of the License, or
# (at your option) any later version.
#
# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with this program; if not, write to the Free Software
# Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

# -*- coding: utf-8 -*- 

###########################################################################
## Python code generated with wxFormBuilder (version Oct  8 2012)
## http://www.wxformbuilder.org/
##
## PLEASE DO "NOT" EDIT THIS FILE!
###########################################################################

import wx
import serial

###########################################################################
## Class MyPanel1
###########################################################################

class MyFrame1 ( wx.Frame ):
	
	#def __init__( self, parent ):
	#	wx.Panel.__init__ ( self, parent, id = wx.ID_ANY, pos = wx.DefaultPosition, size = wx.Size( 462,164 ), style = wx.TAB_TRAVERSAL )

	ser = None
	m_button=[]
	for x in range (0, 10):
		m_button.append(object)

	def __init__(self, parent, id, title):
		wx.Frame.__init__(self, parent, id, title, wx.DefaultPosition, wx.Size(462, 164))	

		bSizer1 = wx.BoxSizer( wx.VERTICAL )
		
		bSizer2 = wx.BoxSizer( wx.HORIZONTAL )
		
		self.m_staticText1 = wx.StaticText( self, wx.ID_ANY, u"Select Rover's Device", wx.DefaultPosition, wx.DefaultSize, 0 )
		self.m_staticText1.Wrap( -1 )
		bSizer2.Add( self.m_staticText1, 0, wx.ALL|wx.ALIGN_CENTER_VERTICAL, 5 )
		
		m_comboBox1Choices = []
		self.m_comboBox1 = wx.ComboBox( self, wx.ID_ANY, u"Combo!", wx.DefaultPosition, wx.DefaultSize, m_comboBox1Choices, 0 )
		bSizer2.Add( self.m_comboBox1, 0, wx.ALL, 5 )
		
		self.m_button10 = wx.Button( self, wx.ID_ANY, u"Select", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer2.Add( self.m_button10, 0, wx.ALL, 5 )
		
		
		bSizer1.Add( bSizer2, 0, wx.EXPAND, 5 )
		bSizer3 = wx.BoxSizer( wx.HORIZONTAL )
		
		self.m_button[1] = wx.Button( self, wx.ID_ANY, u"Sharp  Left", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer3.Add( self.m_button[1], 0, wx.ALL, 5 )
		
		self.m_button[2] = wx.Button( self, wx.ID_ANY, u"Forward", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer3.Add( self.m_button[2], 0, wx.ALL, 5 )
		
		self.m_button[3] = wx.Button( self, wx.ID_ANY, u"Sharp  Right", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer3.Add( self.m_button[3], 0, wx.ALL, 5 )
		
		
		bSizer1.Add( bSizer3, 0, wx.EXPAND, 5 )
		bSizer4 = wx.BoxSizer( wx.HORIZONTAL )
		
		self.m_button[4] = wx.Button( self, wx.ID_ANY, u"Left", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer4.Add( self.m_button[4], 0, wx.ALL, 5 )
		
		self.m_button[5] = wx.Button( self, wx.ID_ANY, u"Stop", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer4.Add( self.m_button[5], 0, wx.ALL, 5 )
		
		self.m_button[6] = wx.Button( self, wx.ID_ANY, u"Right", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer4.Add( self.m_button[6], 0, wx.ALL, 5 )
		
		
		bSizer1.Add( bSizer4, 0, wx.EXPAND, 5 )
		bSizer5 = wx.BoxSizer( wx.HORIZONTAL )
		
		self.m_button[7] = wx.Button( self, wx.ID_ANY, u"Reverse Left", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer5.Add( self.m_button[7], 0, wx.ALL, 5 )
		
		self.m_button[8] = wx.Button( self, wx.ID_ANY, u"Backward", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer5.Add( self.m_button[8], 0, wx.ALL, 5 )
		
		self.m_button[9] = wx.Button( self, wx.ID_ANY, u"Reverse Right", wx.DefaultPosition, wx.DefaultSize, 0 )
		bSizer5.Add( self.m_button[9], 0, wx.ALL, 5 )
		
		
		bSizer1.Add( bSizer5, 0, wx.EXPAND, 5 )
		
		
		self.m_button10.Bind( wx.EVT_BUTTON, self.Select )
		for x in range(1, 10):
			self.m_button[x].Bind(wx.EVT_BUTTON, self.defaultMove)

		self.SetSizer( bSizer1 )
		self.Layout()
	
	def Select (self, event):
		self.ser = serial.Serial(self.m_comboBox1.GetValue(), 19200, timeout=1)

	def defaultMove (self, event):
		index = 0
		for x in range(1, 10):
			if (self.m_button[x].GetId() == event.GetId()):
				index = x
		direction = self.getDirectionFromName(self.m_button[index].GetLabel())
		direction = "m" + direction + "                "
		self.ser.write(direction)

	def getDirectionFromName(self, directionString):
		if (directionString == u"Sharp  Left"):
			return "q"
		elif (directionString == u"Sharp  Right"):
			return "e"
		elif (directionString == u"Forward"):
			return "w"
		elif (directionString == u"Backward"):
			return "s"
		elif (directionString == u"Left"):
			return "a"
		elif (directionString == u"Right"):
			return "d"
		elif (directionString == u"Stop"):
			return "x"
		elif (directionString == u"Reverse Right"):
			return "c"
		elif (directionString == u"Reverse Left"):
			return "z"
		else:
			return "|"


	def __del__( self ):
		pass
	
	
if __name__ == '__main__':
	app = wx.App()
	frame = MyFrame1(None, -1, "Karkhana Rover")
	frame.Show()
	app.MainLoop()


