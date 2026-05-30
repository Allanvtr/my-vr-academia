import Logo from "../../components/Logo";
import Ionicons from 'react-native-vector-icons/Ionicons';
import * as S from './styles'
import CustomButton from "../../components/CustomButton";
import MetricCard from "../../components/MetricCard"
import { useAppNavigation } from "../../hooks/useAppNavigation";
import BottomBar from "../../components/BottomBar";

export default function ContentPage(){
    const navigation = useAppNavigation();

    const metrics = [
        {metric: "5", icon: "people-outline"},
        {metric: "9", icon: "volume-medium-outline"},
        {metric: "5", icon: "sunny-outline"},
        {metric: "13", icon: "help-circle-outline"},
        {metric: "5:00", icon: "hourglass-outline"},
    ]

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
            <S.FileButton>
                <S.FileButtonText>
                    Selecionar Arquivo
                </S.FileButtonText>
            </S.FileButton>
            <S.SectionTitle>
                Resumo
            </S.SectionTitle>

            <S.AbstractContainer>
                {metrics.map((item, index) => (
                    <MetricCard
                        key={index}
                        metric={item.metric}
                        icon={item.icon}
                    />
                ))}
            </S.AbstractContainer>
            <CustomButton
                name="Iniciar"
                onClick={() => {}}
            />
            <BottomBar/>
        </S.Container>
    );
}