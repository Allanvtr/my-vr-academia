import Logo from "../../components/Logo";
import Ionicons from 'react-native-vector-icons/Ionicons';
import * as S from './styles'
import CustomButton from "../../components/CustomButton";
import MetricCard from "../../components/MetricCard"
import { useAppNavigation } from "../../hooks/useAppNavigation";
import BottomBar from "../../components/BottomBar";
import { RootStackParamList } from '../../navigation';
import { RouteProp } from '@react-navigation/native';
import { metrics } from '../../constants/metrics';

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
                        metric={metricValues[item.metric]}
                        icon={item.icon}
                    />
                ))}
            </S.AbstractContainer>
            <CustomButton
                name="Iniciar"
                onClick={() => {console.log(title, metricValues)}}
            />
            <BottomBar/>
        </S.Container>
    );
}