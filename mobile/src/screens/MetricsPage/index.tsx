import Logo from "../../components/Logo";
import { Slider } from '@miblanchard/react-native-slider';
import { useState } from 'react';
import { useTheme } from 'styled-components/native';
import MetricButton from "../../components/MetricButton";
import Button from "../../components/Button"
import * as S from './styles'

const metrics = [
    {metric: "Público", icon: "people-outline"},
    {metric: "Ruído", icon: "volume-medium-outline"},
    {metric: "Brilho", icon: "sunny-outline"},
    {metric: "Perguntas", icon: "help-circle-outline"},
    {metric: "Tempo", icon: "hourglass-outline"},
]

export default function MetricsPage() {
    const theme = useTheme();
    
    const [minValue, setMinValue] = useState(0);
    const [maxValue, setMaxValue] = useState(10);
    const [sliderValue, setSliderValue] = useState(minValue);
    const [metric, setMetric] = useState("Público")

    const percentage = ((sliderValue - minValue) / (maxValue - minValue)) * 100;

    return (
        <S.Container>
            <Logo/>
            <S.MetricTitle>
                {metric}
            </S.MetricTitle>

            <S.SliderContainer>
                
                <S.FloatingNumberContainer>
                    <S.FloatingNumber percentage={percentage}>
                        {Math.round(sliderValue)}
                    </S.FloatingNumber>
                </S.FloatingNumberContainer>

                <S.SliderWrapper>
                    <Slider
                        minimumValue={minValue}
                        maximumValue={maxValue}
                        value={sliderValue}
                        onValueChange={(value) => setSliderValue(value[0])}
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
                        metric={item.metric}
                        icon={item.icon}
                        onPress={() => setMetric(item.metric)}
                    />
                ))}
            </S.MetricsButtonsContainer>
            <S.SubmitButtonContainer>
                <Button
                    name="Avançar"
                />
            </S.SubmitButtonContainer>
            
        </S.Container>
    );
}