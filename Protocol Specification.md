WiFi Barcode Scanner - Protocol Specification
=============================================

WiFi Barcode Scanner communicates by UDP packets over Ethernet. The Android app discovers available computers running the WiFi Barcode Scanner software by sending a "WiFi Barcode Scanner Broadcast"-packet and the computer software responds with a "WiFi Barcode Scanner Response"-packet.

The packet payload is UTF-8 encoded plain text.



WiFi Barcode Scanner Broadcast Packet
-------------------------------------
The "WiFi Barcode Scanner Broadcast"-packet always starts with the text "WiFi Barcode Scanner Broadcast". The version code and the version name of the app is also included. The parameters in the packet is delimited by a pipe character (|).

An example packet could be:
"WiFi Barcode Scanner Broadcast|5|1.1"

When the WiFi Barcode Scanner computer software receives this packet, it responds with a "WiFi Barcode Scanner Response"-packet.



WiFi Barcode Scanner Response Packet
------------------------------------
The "WiFi Barcode Scanner Response"-packet always starts with the text "WiFi Barcode Scanner Response", followed by the computer client version, the computer ID and the UDP port the client software is listening for "WiFi Barcode Scanner Barcode"-packets on. The parameters in the packet is delimited by a pipe character (|).

An example packet could be:
"WiFi Barcode Scanner Response|1.3|Office Computer|18439"



WiFi Barcode Scanner Barcode Packet
-----------------------------------
Whenever a barcode has been read by the WiFi Barcode Scanner app, it send a "WiFi Barcode Scanner Barcode"-packet to the selected computer client.

The "WiFi Barcode Scanner Barcode"-packet always starts with the text "WiFi Barcode Scanner Barcode", followed by the barcode. The parameters in the packet is delimited by a pipe character (|).

An example packet could be:
"WiFi Barcode Scanner Barcode|8195710086"