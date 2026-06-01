export const scenes = {
    "Sala de Aula": {
        id: "sala-de-aula",
        image: "classroom.png",
    },

    "Laboratório": {
        id: "laboratorio",
        image: "lab.png",
    },
} as const;

export type SceneName = keyof typeof scenes;