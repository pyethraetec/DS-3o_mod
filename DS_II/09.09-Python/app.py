

print ('hello world')
nome = input("Insira seu nome: ")
print (nome)

ano = input("Qual o ano do seu nascimento? ")
print(type(ano))
ano = int (ano) # Convertendo string para int

idade = 2024 - ano
print (f"Sua idade é {idade}") #f = string formatada

if idade >= 18:
    print ("Pode beber, votar e dirigir")
elif idade >=16 and idade >=14:
    print ("só pode votar")

else: 
    print ("Não pode fazer nada")


#While
i=1
while i<6:
    print(i)
    i +=1

minhas_frutas = ["maçã", "banana", "morango"]
for fruta in minhas_frutas:
    print(f"{fruta}\n")


def Somar():
    num1 = int(print("Digite um num: \n"))
    num2 = int(print("Digite outro num: \n"))
    print (f"a Soma é: {num1+num2}")

