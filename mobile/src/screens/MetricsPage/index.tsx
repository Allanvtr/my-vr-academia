import Logo from "../../components/Logo";
import { Slider } from '@miblanchard/react-native-slider'; // Importação corrigida (não usa default export)
import { useState } from 'react';
import styled, { useTheme } from 'styled-components/native';
import MetricButton from "../../components/MetricButton";

export const Container = styled.View`
  flex: 1;
  background-color: ${({ theme }) => theme.colors.background};
`;

const MetricName = styled.Text`
    text-align: center;
    font-size: 30px;
    font-family: ${({ theme }) => theme.fonts.semiBold};
    margin-top: 40px;
`;

const SliderContainer = styled.View`
    margin-top: 40px;
    position: relative;
    justify-content: flex-end;
`;

const SliderStyle = styled.View`
    width: 80%;
    align-self: center;
`;

const TrackWrapper = styled.View`
    position: absolute;
    width: 80%;
    /* Reduzi o padding pois essa biblioteca é mais precisa nas bordas */
    padding-horizontal: 10px; 
    bottom: 35px;
    align-self: center;
`;

const FloatingNumber = styled.Text<{ percentage: number }>`
    font-size: 16px;
    font-family: ${({ theme }) => theme.fonts.semiBold};
    color: #000000;
    text-align: center;
    width: 30px;
    
    left: ${({ percentage }) => percentage}%;
    transform: translateX(-15px); 
`;

export default function MetricsPage() {
    const theme = useTheme();
    
    const MIN_VALUE = 10;
    const MAX_VALUE = 90;
    
    const [sliderValue, setSliderValue] = useState(MIN_VALUE);

    const percentage = ((sliderValue - MIN_VALUE) / (MAX_VALUE - MIN_VALUE)) * 100;

    return (
        <Container>
            <Logo/>
            <MetricName>
                Testando essa bomba
            </MetricName>

            <SliderContainer>
                
                <TrackWrapper>
                    <FloatingNumber percentage={percentage}>
                        {Math.round(sliderValue)}
                    </FloatingNumber>
                </TrackWrapper>

                <SliderStyle>
                    <Slider
                        minimumValue={MIN_VALUE}
                        maximumValue={MAX_VALUE}
                        value={sliderValue}
                        onValueChange={(value) => setSliderValue(value[0])}
                        minimumTrackTintColor={theme.colors.secondary}
                        maximumTrackTintColor="#D3D3D3"
                        
                        trackStyle={{ height: 12, borderRadius: 6 }} 
                        thumbStyle={{ backgroundColor: theme.colors.secondary, width: 24, height: 24, borderRadius: 12 }} 
                    />
                </SliderStyle>
                
            </SliderContainer>
            <MetricButton
                icon="help-outline"
                metric="teste"
            />
        </Container>
    );
}