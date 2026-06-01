import Logo from "../../components/Logo";
import { Slider } from '@miblanchard/react-native-slider';
import { useState } from 'react';
import { useTheme } from 'styled-components/native';
import MetricButton from "../../components/MetricButton";
import CustomButton from "../../components/CustomButton"
import * as S from './styles'
import Ionicons from 'react-native-vector-icons/Ionicons';
import BottomBar from "../../components/BottomBar";
import { useAppNavigation } from '../../hooks/useAppNavigation';
import { RootStackParamList } from '../../navigation';
import { RouteProp } from '@react-navigation/native';
import { metrics } from '../../constants/metrics';
import { MetricType } from '../../types/metrics'
import { formatTime } from '../../utils/formatTime'

type MetricsPageRouteProp = RouteProp<
  RootStackParamList,
  'MetricsPage'
>;

type Props = {
  route: MetricsPageRouteProp;
};

export default function MetricsPage({ route }: Props) {
    const { title } = route.params;
    const theme = useTheme();
    const navigation = useAppNavigation();

    const [metricValues, setMetricValues] = useState<Record<MetricType, number>>({
        Público: 0,
        Ruído: 0,
        Brilho: 0,
        Perguntas: 0,
        Tempo: 0,
    });

    const metricConfig: Record<MetricType, { min: number; max: number }> = {
        Público: { min: 0, max: 50 },
        Ruído: { min: 0, max: 10 },
        Brilho: { min: 0, max: 10 },
        Perguntas: { min: 0, max: 10 },
        Tempo: { min: 0, max: 48 },
    };

    const [selectedMetric, setselectedMetric] = useState<MetricType>("Público")
    const sliderValue = metricValues[selectedMetric];

    const changeMetric = (newMetric: MetricType) => {
        setselectedMetric(newMetric);
    }

    const { min, max } = metricConfig[selectedMetric];
    const percentage = ((sliderValue - min) / (max - min)) * 100;

    return (
        <S.Container>
            <S.TopContainer>
                <S.BackButton
                    onPress={() => navigation.goBack()}
                >
                    <Ionicons
                        name="arrow-back-outline"
                        size={41}
                        color="black"
                    />
                </S.BackButton>
                <Logo/>
            </S.TopContainer>
            <S.MetricTitle>
                {selectedMetric}
            </S.MetricTitle>

            <S.SliderContainer>
                
                <S.FloatingNumberContainer>
                    <S.FloatingNumber percentage={percentage}>
                        {selectedMetric === 'Tempo'
                            ? formatTime(sliderValue)
                            : Math.round(sliderValue)
                        }
                    </S.FloatingNumber>
                </S.FloatingNumberContainer>

                <S.SliderWrapper>
                    <Slider
                        minimumValue={min}
                        maximumValue={max}
                        step={1}
                        value={sliderValue}
                        onValueChange={(value) =>
                            setMetricValues(prev => ({
                                ...prev,
                                [selectedMetric]: Math.round(value[0])
                            }))
                        }
                        minimumTrackTintColor={theme.colors.secondary}
                        maximumTrackTintColor="#D3D3D3"
                        
                        trackStyle={{ height: 12, borderRadius: 6 }} 
                        thumbStyle={{ backgroundColor: theme.colors.secondary, width: 24, height: 24, borderRadius: 12 }} 
                    />
                </S.SliderWrapper>
                
            </S.SliderContainer>
            <S.MetricsButtonsContainer>
                {metrics.map((item) =>(
                    <MetricButton
                        key={item.metric}
                        metric={item.metric}
                        icon={item.icon}
                        selected={selectedMetric === item.metric}
                        onPress={() => changeMetric(item.metric)}
                    />
                ))}
            </S.MetricsButtonsContainer>
            <CustomButton
                name="Avançar"
                onClick={() => navigation.navigate('ContentPage', {
                    title,
                    metricValues
                })}
            />
            <BottomBar/>
        </S.Container>
    );
}