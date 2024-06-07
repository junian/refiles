# You need following packages:
#
#    Rinjdael for Python3 (https://github.com/meyt/py3rijndael)
#    pip install py3rijndael
#
#    PyCryptodome for PBKDF2 (https://github.com/Legrandin/pycryptodome)
#    pip install pycryptodome
#

import base64
import os
import sys

from Crypto.Protocol.KDF import PBKDF2
from Crypto.Hash import SHA1
from py3rijndael import RijndaelCbc, Pkcs7Padding

def decrypt(cipherText, passPhrase):
    array = base64.b64decode(cipherText)
    salt = array[:32]
    rgbIV = array[32:64]
    array2 = array[64:]

    bytes = PBKDF2(passPhrase.encode('utf-8'), salt, dkLen=32, count=1000, hmac_hash_module=SHA1)

    # print(base64.b64encode(bytes))

    # BlockSize = 256 bit = 32 bytes
    rijndael_cbc = RijndaelCbc(
        key=bytes,
        iv=rgbIV,
        padding=Pkcs7Padding(32),
        block_size=32
    )
    
    result = rijndael_cbc.decrypt(array2)
    # print(decoded)
    return result.decode('utf-8')

# Example usage

# it's constant, never change it
passPhrase = "DigitalCraftHipPOS" 

#cipherText = ""  

#decrypted_text = decrypt(cipherText, passPhrase)
# print(decrypted_text)

fn = sys.argv[1]
if os.path.exists(fn):
    print("[INFO] Decrypting " + os.path.basename(fn) + " ... ")
    #open text file in read mode
    text_file = open(fn, "r")
    #read whole file to a string
    cipherText = text_file.read()
    #close file
    text_file.close()
    
    decrypted_text=decrypt(cipherText, passPhrase)
    print("[INFO] Connection String: ")
    print("       " + decrypted_text)
else:
    print("[ERROR] " + fn + " doesn't exist.")
