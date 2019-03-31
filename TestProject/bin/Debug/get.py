import os
from pocketsphinx import LiveSpeech, get_model_path
file = open("ready.st","w")	
file.write("false")
file.close()


model_path = get_model_path()
speech = LiveSpeech(
    verbose=False,
    sampling_rate=16000,
    buffer_size=2048,
    no_search=False,
    full_utt=False,
    hmm=os.path.join(model_path, 'zero_ru.cd_cont_4000'),
    lm=os.path.join(model_path, 'ru.lm'),
    dic=os.path.join(model_path, 'ru.dic'))
file = open("ready.st","w")	
file.write("true")
file.close()
print("Yes")
for phrase in speech:
	print(phrase)
	wFile = open("vol.txt","w")
	wFile.write(str(phrase))
	wFile.close()






