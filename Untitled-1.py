# 1. Base de Conocimientos
reglas = [
    {"si": ["fiebre", "tos"], "entonces": "posible infección respiratoria"},
    {"si": ["dolor_cabeza", "nauseas"], "entonces": "migraña"},
    {"si": ["fiebre", "erupcion"], "entonces": "posible varicela"}
]

# 2. Motor de Inferencia
def motor_inferencia(hechos):
    conclusiones = []
    for regla in reglas:
        if all(cond in hechos for cond in regla["si"]):
            conclusiones.append(regla["entonces"])
    return conclusiones

# 3. Interfaz / Entrada de Datos
hechos_usuario = ["fiebre", "tos"]

# 4. Ejecución
resultado = motor_inferencia(hechos_usuario)
print("Diagnóstico:", resultado)

























# 1. Pedimos al usuario que escriba (el programa se detendrá aquí esperando)
#entrada = input("Escribe tus síntomas separados por coma (ej: fiebre,tos): ")

# 2. Convertimos ese texto en una lista separando por la coma
#hechos_usuario = entrada.split(",")