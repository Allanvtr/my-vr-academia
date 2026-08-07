import Logo from "../../components/Logo";
import Ionicons from 'react-native-vector-icons/Ionicons';
import styled from "styled-components/native";
import * as S from './styles'
import CustomButton from "../../components/CustomButton";
import MetricCard from "../../components/MetricCard"
import { useAppNavigation } from "../../hooks/useAppNavigation";
import BottomBar from "../../components/BottomBar";
import { RootStackParamList } from '../../navigation';
import { RouteProp } from '@react-navigation/native';
import { metrics } from '../../constants/metrics';
import { pick } from '@react-native-documents/picker';
import { useState } from 'react';
import { DocumentPickerResponse } from '@react-native-documents/picker';
import api from "../../services/api";
import { NativeModules } from 'react-native';

type ContentPageRouteProp = RouteProp<
  RootStackParamList,
  'ContentPage'
>;

type Props = {
  route: ContentPageRouteProp;
};

export default function ContentPage({ route }: Props){
    const navigation = useAppNavigation();
    const { title, metricValues }= route.params;
    const [selectedFile, setSelectedFile] = useState<DocumentPickerResponse | null>(null);
    const [errorMessage, setErrorMessage] = useState(false);

    const pickFile = async () => {
        try {
            const [file] = await pick({
                type: [
                    'application/pdf',
                ],
            });

            setSelectedFile(file);

            console.log("arquivo: ", file);

        } catch (error) {
            console.log(error);
        }
    };

    const startScene = async () => {
        if(selectedFile == null){
            setErrorMessage(true);
            return;
        }
        const formData = new FormData();

        formData.append("questionCount", metricValues.Perguntas);
        formData.append("file", {
            uri: selectedFile.uri,
            type: selectedFile.type,
            name: selectedFile.name,
        } as any);

        try {
            // const response = await api.post('/Scene/start', formData);
            // console.log('Response:', response.data);
            NativeModules.UnityLauncher.openUnityApp(metricValues.Tempo, "Hello from React Native!");
            
        } catch (error: any) {
            console.log('Erro', error);
        }
    };

    const ErrorMessage = styled.Text`
        color: red;
        text-align: center;
        font-size: 20px;
        font-family: ${({ theme }) => theme.fonts.regular}
    `;

    return(
        <S.Container>

            <S.TopContainer>
                <S.BackButton
                    onPress={navigation.goBack}
                >
                    <Ionicons
                        name="arrow-back-outline"
                        size={41}
                        color="black"
                    />
                </S.BackButton>
                <Logo/>
            </S.TopContainer>

            <S.SectionTitle>
                Título
            </S.SectionTitle>
            <S.TitleInput
                placeholder="Digite o Título"
                placeholderTextColor="#000000"
            />

            <S.SectionTitle>
                Apresentação
            </S.SectionTitle>
            <S.FileDescription>
                Insira a sua apresentação (slides). Ela vai te auxiliar bla bla bla e gerar perguntas.
            </S.FileDescription>
                <S.FileButton onPress={pickFile}>
                    <S.FileButtonText>
                        {selectedFile
                            ? selectedFile.name
                            : "Selecionar Arquivo"}
                    </S.FileButtonText>
                </S.FileButton>
                {errorMessage &&
                    <ErrorMessage>
                        Erro! Insira uma apresentação para iniciar a cena.
                    </ErrorMessage>
                }
                

            <S.SectionTitle>
                Resumo
            </S.SectionTitle>

            <S.AbstractContainer>
                {metrics.map((item, index) => (
                    <MetricCard
                        key={index}
                        metric={metricValues[item.metric]}
                        icon={item.icon}
                    />
                ))}
            </S.AbstractContainer>
            <CustomButton
                name="Iniciar"
                onClick={() => {
                    console.log(title, metricValues)
                    startScene()                
                }}
            />
            <BottomBar/>
        </S.Container>
    );
}