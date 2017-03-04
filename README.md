# Scheerer-Drawing-Lookup-
#Jorge Diaz
#jld5650@gmail.com
#Published for potential employers

This Windows application helps engineers at Scheerer Bearing (Willow Grove, PA) manage thousands of blueprints and CADs.
A simple applications such as this one was requested by Ryan Kennedy(Director of Engineering) and George Rymar(CEO).
At the time the company had about 50 years worth of drawings that were in binders. As an intern, I scanned and renamed all drawings,
designed a simple database to store metadata, and created two programs. One that extracts data from the file names and inserts them
as records into the database, and another to search for and view drawings in a meaningful way instead of flipping through paper. 
I merged both together into one application. When the application was deployed, my internship was complete and I left Scheerer Bearing 
with the satisfaction that I made a difference in a company's day to day operations. This was all done while I was still at college and while
working at UPS. I was programming for about a year and a half at the end of my internship (near-end of 2015).

Instructions 

-Run the application
-Click 'Preset'
-On the next form browse for the database inside the 'Drawing Lookup Test Folder'
-Login using 'JorgeD', '1234'(capitalization matters)
-On the next form click 'Sync Files'
-On the next form click 'Settings'
-On the next form and on each input field, browse or paste the file path for each  corresponding folder inside 'Drawing Lookup Test Folder'
(eg. 'Sync Folder', 'Push Folder', 'Log Folder')

**The Sync Folder is where the end user would user would manually move the files to be synced into the database. The Push Folder is where files
are moved programatically after they are synced. The Log Folder creates a text file report of failures. If a filename does not meet the requirements
(or a file exception) the file will stay in the sync folder. This works exceptionally well with large amounts of files**

-Accept the settings and click 'Start' in the previous form
-In the folders you will see that many files were synced and some didn't meet file name requirements

** File name requirements
PARTNAME-PARTTYPE-DATE-REVISION
ex. 52-SL-AD-010117-REV0
Part types: AD, MD, CD, VD, RD, PD, XD FD(Assembly Drawing, Machine Drawing, Customer Drawing, Vendor Drawing, 
 Roller Drawing, Component Drawing, Finish Drawing, Cage Drawing)
Dates: 6 digit number
Revisions: A-N **

-Go back to the menu form
-The first three buttons take you to datagrids accompanied by Adobe Pdf Readers

**'Full View and Edit' (Admins) lets you view and (Add/Delete/Update) individual files. (Some issues with 'Update' function)
  'Full View' (Admins and Vice Admins) lets you view but not edit.
  'Partial View' (Admins, Vice-Admins, and Sales) only lets you see Customer Drawings with a less capable pdf viewer and image stamp.**

-Click on a record to view file
-Scroll wheel click on a record to view a file in the datagrid section
-Right click to view a file in a folder(Admin/Vice Admin only)
-Type in search to search part name

**I used Microsoft Access being that it was a small office application 5-8 people. I would probably not use it again. We were able to hide the main drawing folder 
from peering eyes while still giving read rights sales. I would do a million things knowing what I know now but I am happy with the results. I would
love to go back to Scheerer Bearing one day and create something better. Their database hold over 13,000 records to this day. Thanks for viewing.**







