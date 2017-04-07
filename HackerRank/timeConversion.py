
import sys
time = input().strip()

isPM = time[-2:] == "PM"

timeSplit = time.split(':')
hour=int(timeSplit[0])
if(isPM and hour != 12):
	hour+=12
if(isPM == False and hour == 12):
	hour = 0

if(hour < 10):
	hour="0" + str(hour)

print("{0}:{1}:{2}".format(hour, timeSplit[1], timeSplit[2][:2]))