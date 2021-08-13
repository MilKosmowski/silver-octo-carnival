net use \\central_pack_3 /delete
net use \\central_pack_5 /delete
net use \\central_pack_6 /delete
net use \\central_pack_7 /delete
net use \\central_pack_8 /delete

net use \\central_pack_3
net use \\central_pack_5
net use \\central_pack_6
net use \\central_pack_7
net use \\central_pack_8

robocopy . "\\central_pack_3\C\Aplikacje\StanowiskoPakujace\Parameter" /njh /njs /ndl /np /xx /XF "AmountPackedThisShift.txt"

robocopy . "\\central_pack_5\C\Aplikacje\StanowiskoPakujace\Parameter" /njh /njs /ndl /np /xx /XF "AmountPackedThisShift.txt"

robocopy . "\\central_pack_6\C\Aplikacje\StanowiskoPakujace\Parameter" /njh /njs /ndl /np /xx /XF "AmountPackedThisShift.txt"
robocopy . "\\central_pack_7\C\Aplikacje\StanowiskoPakujace\Parameter" /njh /njs /ndl /np /xx /XF "AmountPackedThisShift.txt"
robocopy . "\\central_pack_8\C\Aplikacje\StanowiskoPakujace\Parameter" /njh /njs /ndl /np /xx /XF "AmountPackedThisShift.txt"


pause